using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Listener.BLL;

namespace Listener.Console
{
    public class Listener
    {
        #region LocalVariable
        
        
        #endregion

        public static void Main(string[] args)
        {
            try
            {
                //open thread to receip data from devices
                BLL.GPSDataBLL _GPSDataBLL = new BLL.GPSDataBLL();
                Thread _thread = new Thread(new ThreadStart(_GPSDataBLL.ListenToGPS));
                _thread.Start();
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
