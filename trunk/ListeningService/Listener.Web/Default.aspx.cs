using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

namespace Listener.Web
{
    public partial class Default : System.Web.UI.Page
    {
        #region LocalVariable
        BLL.GPSDataBLL _GPSDataBLL = new BLL.GPSDataBLL();
        Thread _thread;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //open thread to receip data from devices

                _thread = new Thread(new ThreadStart(_GPSDataBLL.ListenToGPS));
                _thread.Start();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}