using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ListeningSocketGPS
{
    class SocketGPS
    {

        private int _intPort=2200;
        private TcpListener GPSListener;
        
        //want to set Port in outsite of SocketGps but cannot call.FAIL!!!
        public void setPort(int pPortValue){_intPort = pPortValue;}
        public int getPort(){return _intPort;}
        
        //this method to set listening information
        public void CreateSocket(){
            try
            {
                GPSListener = new TcpListener(IPAddress.Any, getPort());//Create Listener with IPAddress and Port
                GPSListener.Start();
                while (true)
                {
                    TcpClient client = (TcpClient)GPSListener.AcceptTcpClient();//accept connect from device
                    Thread threadReceiptData = new Thread(new ParameterizedThreadStart(CreateStream));//Open thread to write data while it is continuing to receipt data from device
                    threadReceiptData.Start(client);
                }
                //CreateStream();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        private void CreateStream(object client) {
            try
            {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream networkStream = tcpClient.GetStream();//Create networkSteam to hold data in byecode

                //need to replace by getout the string to insert to database
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] message = new byte[4096];
                int bytesRead;
                bytesRead = networkStream.Read(message, 0, 4096);
                System.Console.WriteLine(encoding.GetString(message, 0, bytesRead));//convert byecode message and write on console
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
