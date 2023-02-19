using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Massey_Omura_Lib
{
    public class Server
    {
        IPEndPoint bindEndPoint;
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

        }
    }
}
