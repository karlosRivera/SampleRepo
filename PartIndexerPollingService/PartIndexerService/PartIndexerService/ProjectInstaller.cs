using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace PartIndexerService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            this.AfterInstall += new InstallEventHandler(ServiceInstaller_AfterInstall);
            //this.BeforeRollback += new InstallEventHandler(ServiceInstaller_BeforeRollback);
            //this.BeforeUninstall += new InstallEventHandler(ServiceInstaller_BeforeUninstall);
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            //using (ServiceController oService = new ServiceController(serviceInstaller1.ServiceName))
            //{
            //    if (oService.Status == ServiceControllerStatus.Running)
            //    {
            //        oService.Stop();
            //    }

            //    if (oService.Status.Equals(ServiceControllerStatus.Stopped) || oService.Status.Equals(ServiceControllerStatus.StopPending))
            //    {
            //        oService.Start();
            //    }
            //}

            using (ServiceController oService = new ServiceController(serviceInstaller1.ServiceName))
            {
                oService.Start();
            }
        }

        //void ServiceInstaller_BeforeRollback(object sender, InstallEventArgs e)
        //{
        //    using (ServiceController oService = new ServiceController(serviceInstaller1.ServiceName))
        //    {
        //        if (oService.Status.Equals(ServiceControllerStatus.Running))
        //        {
        //            oService.Stop();
        //        }
        //    }
        //}

        //void ServiceInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        //{
        //    using (ServiceController oService = new ServiceController(serviceInstaller1.ServiceName))
        //    {
        //        if (oService.Status.Equals(ServiceControllerStatus.Running))
        //        {
        //            oService.Stop();
        //        }
        //    }
        //}
    }
}

/*
installutil.exe /i PartIndexerService.exe
installutil.exe /u PartIndexerService.exe


C:\Users\tridip.BBAKOLKATA\Documents\Visual Studio 2010\Projects\PartIndexerService\PartIndexerService\bin\Debug
*/