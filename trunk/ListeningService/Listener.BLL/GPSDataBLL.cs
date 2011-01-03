using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Listener.DTO;
using Listener.DAL;

//using AgrondTheOne.Library.SocketThread;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Listener.BLL
{
    public class GPSDataBLL
    {
        #region LocalVariable     

        private int _intPort = 3306;
        private TcpListener GPSListener;
        //SocketGPS _SocketGPS = new SocketGPS();
        CutingString _CutGPSData = new CutingString();
        //DAL.GPSDataDAO _GPSDataDAO = new DAL.GPSDataDAO();
        GPS_DataControl _GPS_DataControl = new GPS_DataControl();
        GPS_DataInfo _GPS_DataInfo = new GPS_DataInfo();
        string sErr = "";
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
                _GPS_DataInfo = _CutGPSData.CutStringGPSData(strGPSData, "GPRMC");
                //_GPS_DataControl.Add(_GPS_DataInfo, ref sErr);                
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
