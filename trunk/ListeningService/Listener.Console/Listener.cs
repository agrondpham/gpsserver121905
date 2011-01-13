using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;


namespace Listener.Console
{
    public class Listener
    {
        #region LocalVariable
        BLL.GPSDataBLL _GPSDataBLL = new BLL.GPSDataBLL();
        Thread _thread;
        #endregion

        public static void Main(string[] args)
        {
            Console.Listener console = new Console.Listener();
            console.run();
        }
        public void run()
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
