namespace Kluster.Client;

public interface ICommunication
{
    void Connect(string serverIp, int port);
    void SendMessage(string message);
    string ReceiveMessage();
    void Close();
}