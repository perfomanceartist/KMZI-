using Massey_Omura_Lib;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using CryptographyLib;


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
                //Случайный ключ AES
                Random rnd = new Random();
                byte[] aesKey = new byte[32];
                rnd.NextBytes(aesKey);


                SendKey(stream, aesKey);
                SendData(stream, message, aesKey);

                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        private void SendData(NetworkStream stream, byte[] data, byte[] aesKey)
        {
            byte[] encrypted = Cryptography.ToAes256(data, aesKey);
            stream.Write(encrypted);
            Debug.WriteLine("Data sent");
        }
        private void SendKey(NetworkStream stream, byte[] aesKey)
        {
            

            Massey_Omura m_o = new Massey_Omura();
            byte[] tA = m_o.getA(aesKey);
            stream.Write(tA);
            Debug.WriteLine("tA sent");

            byte[] tAB = new byte[4092];
            stream.Read(tAB);
            Debug.WriteLine("tAB read");

            byte[] tB = m_o.getB(tAB);
            stream.Write(tB);
            Debug.WriteLine("tB sent");
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