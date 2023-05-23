using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;

public class deepNetworkManager
{
    public static deepNetworkManager DNW;
    IPAddress homeIPAddress;
    IPAddress mainServerIPAddress = IPAddress.Parse("138.201.94.174");
    IPAddress OvervrideIPAddress;
    int mainServerPort = 42069;

    Socket mainConnectionSocket = new Socket(SocketType.Stream,ProtocolType.Tcp);
    public void Awake()
    {
        DNW = this;   
    }
    void Startup()
    {
        IPEndPoint mainServerIPEndpoint = new IPEndPoint(mainServerIPAddress,mainServerPort);
        mainProblemHandler.Debuger.MakePublicDebug("main server IPAddres = "+mainServerIPAddress.ToString(),"deep network handler");
        mainConnectionSocket.Connect(mainServerIPEndpoint);
        byte[] connectCommand = new byte[4];
        //mainConnectionSocket.Send(connectCommand);
    }
    public void Main()
    {
        Startup();
    }
}
