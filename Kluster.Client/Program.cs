using Kluster.Client;

var serverIp = "127.0.0.1"; // Localhost
var port = 5001;

while (true)
{
    Console.WriteLine("Choose protocol (1 for TCP, 2 for UDP):");
    var choice = Console.ReadLine();

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
}