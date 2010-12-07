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
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            Byte[] message = encoding.GetBytes("I am a little busy, come back later!");
            
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2200);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("Hello Server!");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            System.Console.ReadLine();
            
        }
    }
}
