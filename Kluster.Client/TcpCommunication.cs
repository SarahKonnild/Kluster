using System.Net.Sockets;
using System.Text;

namespace Kluster.Client;

public class TcpCommunication : ICommunication
{
    private TcpClient client;
    private NetworkStream stream;

    public void Connect(string serverIp, int port)
    {
        client = new TcpClient();
        client.Connect(serverIp, port);
        stream = client.GetStream();
        Console.WriteLine("Connected to TCP server at " + serverIp + ":" + port);
    }

    public void SendMessage(string message)
    {
        var data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Sent: " + message);
    }

    public string ReceiveMessage()
    {
        var data = new byte[256];
        var bytesRead = stream.Read(data, 0, data.Length);
        var response = Encoding.ASCII.GetString(data, 0, bytesRead);
        return response;
    }

    public void Close()
    {
        stream.Close();
        client.Close();
        Console.WriteLine("TCP connection closed.");
    }
}