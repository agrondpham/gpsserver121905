using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

using System.ServiceProcess;

namespace Listener.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            //... Installer code here
            this.AfterInstall += new InstallEventHandler(ServiceInstaller_AfterInstall);
        }
        //protected override void OnCommitted(System.Collections.IDictionary savedState)
        //{
        //    new ServiceController(serviceInstaller1.ServiceName).Start();
        //}
        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController(serviceInstaller1.ServiceName);
            sc.Start();
        }

    }
}
