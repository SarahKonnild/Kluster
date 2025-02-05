using System.Collections.Concurrent;
using System.Net.Sockets;

namespace Kluster.Core.Client;

public class ClientFactory : IClientFactory
{
    private readonly ConcurrentDictionary<string, (TcpClient tcpClient, UdpClient udpClient)> _clientCache = new();
    private readonly object _lock = new();

    /// <inheritdoc />
    public TcpClient GetTcpClient(string clientKey)
    {
        lock (_lock)
        {
            return !_clientCache.TryGetValue(clientKey, out var client)
                ? CreateClientPair(clientKey).tcpClient
                : client.tcpClient;
        }
    }

    /// <inheritdoc />
    public UdpClient GetUdpClient(string clientKey)
    {
        lock (_lock)
        {
            return !_clientCache.TryGetValue(clientKey, out var client)
                ? CreateClientPair(clientKey).udpClient
                : client.udpClient;
        }
    }

    private (TcpClient tcpClient, UdpClient udpClient) CreateClientPair(string clientKey)
    {
        lock (_lock)
        {
            var clientDetails = clientKey.Split(':');
            var tcpClient = new TcpClient(clientDetails[0], int.Parse(clientDetails[1]));
            var udpClient = new UdpClient(clientDetails[0], int.Parse(clientDetails[1]));
            if (_clientCache.TryAdd(clientKey, (tcpClient, udpClient)))
            {
                return (tcpClient, udpClient);
            }

            // TODO do something proper here.
            throw new Exception();
        }
    }

    /// <inheritdoc />
    public bool DeleteClient(string clientId)
    {
        lock (_lock)
        {
            return _clientCache.Remove(clientId, out _);
        }
    }

    internal (TcpClient tcpClient, UdpClient udpClient)? TryGetClientPair(string clientKey)
    {
        lock (_lock)
        {
            _clientCache.TryGetValue(clientKey, out var clientPair);
            return clientPair;
        }
    }
}