using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Massey_Omura_Lib
{
    public class Client
    {
        IPEndPoint remoteEndPoint;
        Socket socket;
        public Client(string IP, string Port)
        {
            IPAddress ipAddr = IPAddress.Parse(IP);
            remoteEndPoint = new(ipAddr, Int32.Parse(Port));            
        }

        public bool Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // пытаемся подключиться используя URL-адрес и порт
                socket.Connect(remoteEndPoint);
                Debug.WriteLine($"Подключение установлено");
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;

        }
        public bool Send(byte[] data)
        {
            try
            {
                int bytesSent = socket.Send(data, SocketFlags.None);
                Debug.WriteLine($"{bytesSent} bytes sent");
            }            
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool Disconnect()
        {
            try
            {
                socket.Disconnect(true);
                Debug.WriteLine("Disconnected");
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}