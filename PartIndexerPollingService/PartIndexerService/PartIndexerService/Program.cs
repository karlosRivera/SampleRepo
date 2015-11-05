using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace PartIndexerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new PartIndexer() 
            };
            ServiceBase.Run(ServicesToRun);


            //#if(!DEBUG)
            //    ServiceBase[] ServicesToRun;
            //    ServicesToRun = new ServiceBase[] 
            //    { 
            //        new PartIndexer() 
            //    };
            //    ServiceBase.Run(ServicesToRun);
            //#else
            //    PartIndexer myServ = new PartIndexer();
            //    myServ.Start();
            //     here Process is my Service function
            //     that will run when my service onstart is call
            //     you need to call your own method or function name here instead of Process();
            //#endif
        }
    }
}
