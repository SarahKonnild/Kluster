using System.Net.Sockets;

namespace Kluster.Core.Client;

/// <summary>
///     Generate or fetch TCP/UDP clients from the client cache.
/// </summary>
public interface IClientFactory
{
    /// <summary>
    ///     Get a TCP Client for the specified client key.
    ///     Client key should be "[IP]:[Port]"
    /// </summary>
    /// <param name="clientKey">The IP and port combination used to identify the client. Separated by :</param>
    /// <returns>The TCP Client.</returns>
    public TcpClient GetTcpClient(string clientKey);

    /// <summary>
    ///     Get a UDP Client for the specified client key.
    ///     Client key should be "[IP]:[Port]"
    /// </summary>
    /// <param name="clientKey">The IP and port combination used to identify the client. Separated by :</param>
    /// <returns>The UDP Client.</returns>
    public UdpClient GetUdpClient(string clientKey);

    /// <summary>
    ///     Delete the client for the specified client key.
    ///     Client key should be "[IP]:[Port]"
    /// </summary>
    /// <param name="clientId">The IP and port combination used to identify the client. Separated by :</param>
    /// <returns>True if the Client was successfully removed from the cache. False otherwise.</returns>
    public bool DeleteClient(string clientId);
}