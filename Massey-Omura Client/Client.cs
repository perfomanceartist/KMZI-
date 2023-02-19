using Massey_Omura_Lib;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Massey_Omura_Client
{
    public class Client
    {
        TcpClient tcpClient;

        public Client(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
        }

        public bool Send(string message)
        {
            return Send(Encoding.UTF8.GetBytes(message));
        }
        public bool Send(byte[] message)
        {
            NetworkStream stream = tcpClient.GetStream();

            // Send the message to the connected TcpServer.
            try
            {
                stream.Write(message, 0, message.Length);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }


        /*IPEndPoint remoteEndPoint;
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
        }*/
    }
}