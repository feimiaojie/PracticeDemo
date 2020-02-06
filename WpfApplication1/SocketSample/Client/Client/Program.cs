using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 6000;
            string host = "127.0.0.1";//服务器端ip地址

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ipe);



            while (true)
            {
                string input = Console.ReadLine();
                if (input == "close")
                {
                    clientSocket.Close();
                }
                else
                {
                    byte[] sendBytes = Encoding.ASCII.GetBytes(input);
                    clientSocket.Send(sendBytes);
                }
            }

        }
    }
}
