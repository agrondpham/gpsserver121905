using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using AgrondTheOne.Library.SocketThread;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace ListeningGPS.BLL
{
    public class GPSDataBLL
    {
        #region LocalVariable     

        private int _intPort = 2200;
        private TcpListener GPSListener;
        //SocketGPS _SocketGPS = new SocketGPS();
        CutingString _CutGPSData = new CutingString();
        DAL.GPSDataDAO _GPSDataDAO = new DAL.GPSDataDAO();

        //want to set Port in outsite of SocketGps but cannot call.FAIL!!!
        public void setPort(int pPortValue) { _intPort = pPortValue; }
        public int getPort() { return _intPort; }

        #endregion
        public void ListenToGPS()
        {
            try
            {
                //call method for listening information form devices

                CreateSocket();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        //this method to set listening information
        public void CreateSocket()
        {
            try
            {
                GPSListener = new TcpListener(IPAddress.Any, _intPort);//Create Listener with IPAddress and Port
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
        private void CreateStream(object client)
        {
            try
            {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream networkStream = tcpClient.GetStream();//Create networkSteam to hold data in byecode

                //need to replace by getout the string to insert to database
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] message = new byte[4096];
                int bytesRead;
                bytesRead = networkStream.Read(message, 0, 4096);
                string strGPSData = encoding.GetString(message, 0, bytesRead);                
                //Need checksum
                //ConvertData Data
                ArrayList strArrayGPSData = _CutGPSData.CutStringGPSData(strGPSData, "GPRMC");
                if (_GPSDataDAO.InsertData(strArrayGPSData)==false)
                {
                    System.Console.WriteLine("Error when inserting data");
                }
                tcpClient.Close();
                //return strGPSData;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                //return "Error when recepting data";
            }
        }
    }
}
