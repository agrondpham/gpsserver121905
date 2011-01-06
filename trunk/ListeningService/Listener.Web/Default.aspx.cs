using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Threading;
using System.IO;

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
            path = Server.MapPath("loi.txt");
            try
            {
                //open thread to receip data from devices

                _thread = new Thread(new ThreadStart(_GPSDataBLL.ListenToGPS));
                _thread.Start();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                TextWriter streamWr = new StreamWriter(path);
                streamWr.Write(ex.ToString());
            }
        }
    }
}