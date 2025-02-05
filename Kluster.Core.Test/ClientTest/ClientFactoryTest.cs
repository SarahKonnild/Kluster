using System.Net.Sockets;
using Kluster.Core.Client;

namespace Kluster.Core.Test.ClientTest;

public class ClientFactoryTest
{
    private const string ClientKey = "127.0.0.1:8000";
    private readonly ClientFactory _clientFactory = new();

    [Fact]
    public void Should_GenerateClientPair_When_GettingTcpClientWithNoneCached()
    {
        // TODO test this. Set up small server in ctor to test against?
        // ACT
        // var tcpClient = _clientFactory.GetTcpClient(ClientKey);
        
        // ASSERT
        // Assert.IsType<TcpClient>(tcpClient);
    }
}