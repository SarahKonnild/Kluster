using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Kluster.Client;

public class UdpCommunication : ICommunication
{
    private UdpClient udpClient;
    private IPEndPoint remoteEndPoint;

    public void Connect(string serverIp, int port)
    {
        udpClient = new UdpClient();
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        Console.WriteLine("Connected to UDP server at " + serverIp + ":" + port);
    }

    public void SendMessage(string message)
    {
        var data = Encoding.ASCII.GetBytes(message);
        udpClient.Send(data, data.Length, remoteEndPoint);
        Console.WriteLine("Sent: " + message);
    }

    public string ReceiveMessage()
    {
        var data = udpClient.Receive(ref remoteEndPoint);
        var response = Encoding.ASCII.GetString(data);
        return response;
    }

    public void Close()
    {
        udpClient.Close();
        Console.WriteLine("UDP connection closed.");
    }
}