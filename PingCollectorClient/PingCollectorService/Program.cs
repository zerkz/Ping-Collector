using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;



namespace PingCollectorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {

           
            if (args.Length > 0)  
            {
               
                if (args[0] == "/i")
                {
       
                        try
                        {
                            System.Configuration.Install.ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });   
                        }
                        catch (System.Configuration.Install.InstallException e)
                        {
                            
                        }
                   

                }
                else if (args[0] == "/u")
                {
                    try
                    {
                        System.Configuration.Install.ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                    }catch (System.Configuration.Install.InstallException e){
                        Console.WriteLine("Service was not installed, and therefore could not be uninstalled.");
                    }
                }

            }
            else
            {
             
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new PingCollectorService() 
            };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
