using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace ClientSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2200);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("$GPRMC,040302.663,A,3939.7,N,10506.6,W,0.27,358.86,200804,,*1A");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            System.Console.ReadLine();
            
        }
    }
}
