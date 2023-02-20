using Massey_Omura_Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CryptographyLib;


namespace Massey_Omura_Client
{
    public class Server
    {
        TcpListener tcpListener;
        public Server(string IP, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(IP), port);
            tcpListener.Start();
        }

        private byte[] AcceptData(NetworkStream stream, byte[] aesKey)
        {
            byte[] data = new byte[1024];
            int bytesReadTotal = 0;
            while (true)
            {
                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(data, bytesReadTotal, 1024);
                }
                catch (Exception ex)
                {

                }
                
                bytesReadTotal += bytesRead;
                if (bytesRead < 1024) break;
                Array.Resize<byte>(ref data, bytesReadTotal + 1024);
            }
            Array.Resize<byte>(ref data, bytesReadTotal);
            Debug.WriteLine($"Data read ({0} bytes)", bytesReadTotal);
            return Cryptography.FromAes256(data, aesKey);
        }


        private byte[] AcceptKey(NetworkStream stream)
        {
            Massey_Omura m_o = new Massey_Omura();

            byte[] tA = new byte[1024];
            stream.Read(tA);
            Debug.WriteLine("tA read");

            byte[] tAB = m_o.getAB(tA);
            stream.Write(tAB);
            Debug.WriteLine("tAB sent");

            byte[] tB = new byte[1024];
            stream.Read(tB);
            Debug.WriteLine("tB read");

            return m_o.getT(tB);


        }

        public Message Listen()
        {
            
            using TcpClient client = tcpListener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] key = AcceptKey(stream);
            byte[] data = AcceptData(stream, key);


            string date = DateTime.UtcNow.ToString();
            return new Message(client.Client.RemoteEndPoint.ToString(), date, data);
        }
        ~Server()
        {
            tcpListener.Stop();
        }


        /*IPEndPoint bindEndPoint;
        public Socket socket;

        public Server(string IP, string Port)
        {
            IPAddress ipAddr = IPAddress.Parse(IP);
            bindEndPoint = new(ipAddr, Int32.Parse(Port));
        }

        public void StartListening()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(bindEndPoint);
            socket.Listen(1000);
        }

        public async Task<Message> GetMessage()
        {
            var responseBytes = new byte[512];
            Debug.WriteLine("Сервер запущен. Ожидание подключений...");
            // получаем входящее подключение
            Socket client = await Task.Run(() => socket.Accept());
            Debug.WriteLine("client connected:" + socket.Connected);
            // получаем адрес клиента
            Debug.WriteLine($"Адрес подключенного клиента: {client.RemoteEndPoint}");

            int bytes = await Task.Run( () =>  socket.ReceiveAsync(responseBytes, SocketFlags.None) ); 

            return new Message(client.RemoteEndPoint.ToString(), "date", responseBytes);

        }*/
    }
}
