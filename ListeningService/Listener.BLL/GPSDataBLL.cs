using System;
using System.Collections.Generic;
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

        private int _intPort = 8282;
        //private string sErr = "";
        private TcpListener GPSListener;
        //SocketGPS _SocketGPS = new SocketGPS();
        CutingString _CutGPSData = new CutingString();
        //DAL.GPSDataDAO _GPSDataDAO = new DAL.GPSDataDAO();
        DAL.ErrorLog ErrorLog = new ErrorLog();
        GPS_DataControl _GPS_DataControl = new GPS_DataControl();
        GPS_DataInfo _GPS_DataInfo = new GPS_DataInfo();
        string sErr = "";
        //want to set Port in outsite of SocketGps but cannot call.FAIL!!!
        public void setPort(int pPortValue) { _intPort = pPortValue; }
        public int getPort() { return _intPort; }
        string loi = "";
        #endregion
        public void  ListenToGPS()
        {
            try
            {
                //call method for listening information form devices
                CreateSocket();
                //string err = testTCPIP();
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());
                //if (sErr != "") ErrorLog.SetLog(sErr);//return "Error when recepting data";
                //return ex.ToString();
            }
        }
        //this method to set listening information
        public void CreateSocket()
        {
            //return testTCPIP();
            try
            {
                GPSListener = new TcpListener(IPAddress.Any, _intPort);//Create Listener with IPAddress and Port
                GPSListener.Start();
                while (true)
                {
                    TcpClient client = (TcpClient)GPSListener.AcceptTcpClient();//accept connect from device
                    Thread threadReceiptData = new Thread(new ParameterizedThreadStart(CreateStream));//Open thread to write data while it is continuing to receipt data from device
                    threadReceiptData.Start(client);
                    //return CreateStream(client);
                }
                //CreateStream();
                //return "vao toi CreateSocket";
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());
                //if (sErr != "") ErrorLog.SetLog(sErr);//return "Error when recepting data";
                //return ex.ToString();
                //return "loi khong tao duoc socket do bi dung:" + ex.ToString() + "PORT:" + _intPort;
            }
        }
        private void CreateStream(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            try
            {
                
                NetworkStream networkStream = tcpClient.GetStream();//Create networkSteam to hold data in byecode

                //need to replace by getout the string to insert to database
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] message = new byte[4096];
                int bytesRead;
                bytesRead = networkStream.Read(message, 0, 4096);
                string strGPSData = encoding.GetString(message, 0, bytesRead);

                _GPS_DataInfo = _CutGPSData.CutStringGPSData(strGPSData, "GPRMC");
                _GPS_DataControl.Add(_GPS_DataInfo, ref sErr);                
                tcpClient.Close();
                
                //return strGPSData;
            }
            catch (Exception ex)
            {
                tcpClient.Close();
                //System.Console.WriteLine(ex.ToString());
                //sErr = ex.ToString();
                //return sErr;
                //if (sErr != "") ErrorLog.SetLog(sErr);//return "Error when recepting data";
            }
        }
        public string testTCPIP()
        {
            string data = "";
            //string error = "";
            byte[] bytes = new byte[1024];
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(0, 0);

            //create tcp/ip
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket handler = listener;
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                while (true)
                {
                    //Console.WriteLine("cho ket noi");
                    handler = listener.Accept();
                    data = null;
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }
                    //Console.WriteLine("test received:{0}", data);

                    //byte[] msg = Encoding.ASCII.GetBytes(data);
                    //handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    return data;
                }
            }
            catch (Exception ex)
            {

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                return "fail:" + ex.ToString();
            }

        }
    }
}
