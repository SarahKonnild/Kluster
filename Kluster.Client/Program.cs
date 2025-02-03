using Kluster.Client;

var serverIp = "127.0.0.1"; // Localhost
var port = 5001;

while (true)
{
    Console.WriteLine("Choose protocol (1 for TCP, 2 for UDP):");
    string choice = Console.ReadLine();
        
    ICommunication network;

    if (choice == "1")
    {
        network = new TcpCommunication();
    }
    else if (choice == "2")
    {
        network = new UdpCommunication();
    }
    else
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    // Connect using the selected protocol
    network.Connect(serverIp, port);

    // Send a message
    network.SendMessage("Hello from client!");

    // Receive a message
    string response = network.ReceiveMessage();
    Console.WriteLine("Received: " + response);

    // Close the connection
    network.Close();
    
    // try
    // {
    //     // Try to connect to the server
    //     var client = new TcpClient();
    //     client.Connect(serverIp, port);
    //     Console.WriteLine("Connected to server at " + serverIp + ":" + port);
    //
    //     // Get the network stream
    //     var stream = client.GetStream();
    //
    //     // Keep sending/receiving data indefinitely
    //     while (true)
    //     {
    //         // Send a message to the server (this could be based on user input)
    //         var message = "Hello from C# client!";
    //         var data = Encoding.ASCII.GetBytes(message);
    //         stream.Write(data, 0, data.Length);
    //         Console.WriteLine("Sent: " + message);
    //
    //         // Optionally receive a message from the server
    //         var response = new byte[256];
    //         var bytesRead = stream.Read(response, 0, response.Length);
    //         if (bytesRead > 0)
    //         {
    //             string responseMessage = Encoding.ASCII.GetString(response, 0, bytesRead);
    //             Console.WriteLine("Received: " + responseMessage);
    //         }
    //
    //         // Wait a bit before sending the next message (you can change this logic)
    //         Thread.Sleep(5000); // 5 seconds delay
    //     }
    // }
    // catch (SocketException e)
    // {
    //     Console.WriteLine("Connection lost, attempting to reconnect...");
    //     Console.WriteLine("Error: " + e.Message);
    // }
    // catch (Exception e)
    // {
    //     Console.WriteLine("Error: " + e.Message);
    // }
    //
    // // Optionally, you can add a delay before trying to reconnect
    // Thread.Sleep(2000); // 2 seconds delay before attempting to reconnect
}