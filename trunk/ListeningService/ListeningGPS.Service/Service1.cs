using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.Threading;
namespace ListeningGPS.Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        #region LocalVariable
        BLL.GPSDataBLL _GPSDataBLL = new BLL.GPSDataBLL();
        Thread _thread;
        #endregion

        protected override void OnStart(string[] args)
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

        protected override void OnStop()
        {
        }
    }
}
