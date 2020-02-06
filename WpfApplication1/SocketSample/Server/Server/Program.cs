using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 6000;
            string host = "127.0.0.1";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket.Bind(ipe);
            sSocket.Listen(10);
           // sSocket.IOControl(IOControlCode.KeepAliveValues, new byte[4096], null);
            WriteLine("监听已经打开，请等待");

            
            int i = 0;
            while (true)
            {
                i++;
                //receive message
                Socket serverSocket = sSocket.Accept();
                WriteLine("连接已经建立");
               Thread thread = new Thread(new ParameterizedThreadStart(Receive));
                thread.Start(serverSocket);
            }

            //serverSocket.Close();
            sSocket.Close();
            WriteLine("服务端关闭!");
            ReadLine();
        }

        private static void Receive(object serverSocket)
        {
            while (true)
            {
                string recStr = "";


                byte[] recByte = new byte[4096];
                int bytes = ((Socket)serverSocket).Receive(recByte, recByte.Length, 0);
                if (bytes == 0)
                {
                    break;
                }

                recStr += Encoding.ASCII.GetString(recByte, 0, bytes);

                //send message
                WriteLine($"服务器端获得信息:{recStr}");
            }
        }
    }
}
