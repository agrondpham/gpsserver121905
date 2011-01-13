using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Threading;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
namespace Listener.Web
{
    public partial class Default : System.Web.UI.Page
    {
        #region LocalVariable
        BLL.GPSDataBLL _GPSDataBLL = new BLL.GPSDataBLL();
        Thread _thread;
        #endregion
        
        
        public string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            //path = Server.MapPath("loi.txt");
            try
            {
                //open thread to receip data from devices
                string err;

                 _thread = new Thread(new ThreadStart(_GPSDataBLL.ListenToGPS));

                _thread.Start();

                //string error = _GPSDataBLL.ListenToGPS();
                //TextWriter streamWr = new StreamWriter(Server.MapPath("duoc.txt"));
                //streamWr.Write(error);
                //streamWr.Close();
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());
                //TextWriter streamWr = new StreamWriter(path);
                //streamWr.Write(ex.ToString());
                //streamWr.Close();
            }
            testPort();
        }
        public void testPort() {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();
            TextWriter streamWr = new StreamWriter(Server.MapPath("portlist.txt"));
            streamWr.Write("List port by 'netstat -an' \n");
            foreach (TcpConnectionInformation info in tcpConnections)
            {


                streamWr.WriteLine("Local : " + info.LocalEndPoint.Address.ToString()
                + ":" + info.LocalEndPoint.Port.ToString()
                + " Remote : " + info.RemoteEndPoint.Address.ToString()
                + ":" + info.RemoteEndPoint.Port.ToString()
                + " State : " + info.State.ToString() + "\n\n");
            }
            streamWr.Close();   
        }
    }
}