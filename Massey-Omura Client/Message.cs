using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massey_Omura_Client
{
    public class Message
    {
        public string ip;
        public string date;
        public byte[] data;

        public Message(string ip, string date, byte[] data)
        {
            this.ip = ip;
            this.date = date;
            this.data = data;
        }
    }
}
