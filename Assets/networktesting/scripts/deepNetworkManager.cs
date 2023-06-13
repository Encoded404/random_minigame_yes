using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class deepNetworkManager
{
    IPAddress homeIPAddress;
    IPAddress mainServerIPAddress = IPAddress.Parse("138.201.94.174");
    IPAddress overrideIPAddress;
    int mainServerPort = 42069;

    Socket mainConnectionSocket;
    Thread receiveThread;
    bool isReceiving;

    public event EventHandler<string> recievedAnyRawData;
    public event EventHandler<object> recievedAnyData;
    public event EventHandler<object> recievedRandomData;
    public event EventHandler<string> receivedString;
    public event EventHandler<int> receivedInt;
    public event EventHandler<double> receivedDouble;
    public event EventHandler<object> receivedRandomStructData;

    public void Awake()
    {
    }

    void Startup()
    {
        IPEndPoint mainServerIPEndpoint = new IPEndPoint(mainServerIPAddress, mainServerPort);
        mainProblemHandler.Debuger.MakePublicDebug("Main server IPAddress = " + mainServerIPAddress.ToString(), "Deep Network Handler");

        mainConnectionSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        try
        {
            mainConnectionSocket.Connect(mainServerIPEndpoint);
            byte[] connectCommand = new byte[4];
            //mainConnectionSocket.Send(connectCommand);

            // Start receiving data in a separate thread
            receiveThread = new Thread(ReceiveData);
            isReceiving = true;
            receiveThread.Start();

            // You can perform other initialization or data exchange with the server here
        }
        catch (SocketException ex)
        {
            // Handle the exception or notify the appropriate components
        }
    }

    public void Main()
    {
        Startup();
    }

    void ReceiveData()
    {
        while (isReceiving)
        {
            byte[] buffer = new byte[1024]; // Adjust the buffer size as per your needs

            try
            {
                int bytesRead = mainConnectionSocket.Receive(buffer);

                if (bytesRead > 0)
                {
                    // Process the received data
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    ProcessReceivedData(receivedData);
                }
                else
                {
                    // Connection closed by the server
                    break;
                }
            }
            catch (SocketException ex)
            {
                // Handle socket exception
                break;
            }
        }
    }

    void ProcessReceivedData(string data)
    {
        // Process and handle the received data
        // You can raise events, invoke callbacks, or perform any other required logic here
    }

    public void SendData(string data)
    {
        byte[] sendData = Encoding.ASCII.GetBytes(data);

        Thread sendThread = new Thread(() =>
        {
            try
            {
                mainConnectionSocket.Send(sendData);
            }
            catch (SocketException ex)
            {
                // Handle socket exception
            }
        });

        sendThread.Start();
    }

    public void StopReceiving()
    {
        isReceiving = false;
        if (receiveThread != null && receiveThread.IsAlive)
        {
            receiveThread.Join(); // Wait for the receive thread to exit gracefully
        }
    }

    // Implement other methods or event handlers as per your requirements
}