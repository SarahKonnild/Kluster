using System.Net;
using System.Net.Sockets;
using System.Text;

var port = 5001; // not 5000 because winows

TcpListener tcpListener;
UdpClient udpListener;

// Start listening for TCP and UDP concurrently
var tcpThread = new Thread(StartTcpListener);
var udpThread = new Thread(StartUdpListener);

// Start the threads for both listeners
tcpThread.Start();
udpThread.Start();

// Wait for threads to finish (this will keep the main thread alive)
tcpThread.Join();
udpThread.Join();
return;


// TCP Listener method
void StartTcpListener()
{
    tcpListener = new TcpListener(IPAddress.Any, port);
    tcpListener.Start();
    Console.WriteLine("TCP Server is listening on port " + port);

    while (true)
    {
        try
        {
            var tcpClient = tcpListener.AcceptTcpClient();
            var clientThread = new Thread(() => HandleTcpClient(tcpClient));
            clientThread.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine("TCP Listener error: " + ex.Message);
        }
    }
}

// Handle incoming TCP client connection
void HandleTcpClient(TcpClient tcpClient)
{
    var stream = tcpClient.GetStream();

    try
    {
        Console.WriteLine("TCP Client connected");

        // Read data from the client
        var buffer = new byte[256];
        var bytesRead = stream.Read(buffer, 0, buffer.Length);
        var message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("TCP Message received: " + message);

        // Respond to the client
        var response = "TCP Response: " + message;
        var responseBytes = Encoding.ASCII.GetBytes(response);
        stream.Write(responseBytes, 0, responseBytes.Length);
    }
    catch (Exception ex)
    {
        Console.WriteLine("TCP Client error: " + ex.Message);
    }
    finally
    {
        tcpClient.Close();
        Console.WriteLine("TCP Client disconnected");
    }
}

// UDP Listener method
void StartUdpListener()
{
    udpListener = new UdpClient(port);
    Console.WriteLine("UDP Server is listening on port " + port);

    try
    {
        while (true)
        {
            // Receive UDP data
            var udpEndPoint = new IPEndPoint(IPAddress.Any, port);
            var receivedData = udpListener.Receive(ref udpEndPoint);

            var message = Encoding.ASCII.GetString(receivedData);
            Console.WriteLine("UDP Message received: " + message);

            // Respond to the UDP client
            var response = "UDP Response: " + message;
            var responseBytes = Encoding.ASCII.GetBytes(response);
            udpListener.Send(responseBytes, responseBytes.Length, udpEndPoint);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("UDP Listener error: " + ex.Message);
    }
}