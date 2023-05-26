//using System.Collections;
//using System.Collections.Generic;
//using System.Threading;
//using System.Net;
//using System.Net.Sockets;

//public class Main_Network_Script
//{
//    Socket s1 = new Socket(SocketType.Stream, ProtocolType.Tcp);
//    public bool ConnectToServer(int ip,int port)
//    {
//        try
//        {
//            IPEndPoint ipend = new IPEndPoint(ip,port);
//            s1.Connect(ipend);
//            return true;
//        }
//        catch
//        {
//            return false;
//        }
//    }
//    public bool SendToServer(byte[] data)
//    {
//        try
//        {
//            s1.Send(data);
//            return true;
//        }
//        catch
//        {
//            return false;
//        }
//    }
//    void listen()
//    {

//        //s1.Receive()
//    }
//}

//public static class bitwiseOperations
//{
//    static byte setTrue(byte data, int pos)
//    {
//        return (byte)(data | (1 << pos));
//    }
//    static byte setFalse(byte data, int pos)
//    {
//        return (byte)(data & ~(1 << pos));
//    }
//    static public byte setBit(byte data,int pos, bool input)
//    {
//        byte x1 = data;
//        if(input)
//        {
//            x1 = setTrue(x1,pos);
//        }
//       if(!input)
//        {
//            x1 = setFalse(x1,pos);
//        }
//        return x1;
//    }
//}