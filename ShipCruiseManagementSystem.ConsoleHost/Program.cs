using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShipCruiseManagementSystem.ServiceHost;

namespace ShipCruiseManagementSystem.ConsoleHost
{
    public class Program
    {


        static void Main(string[] args)
        {
            var userServiceHost = new UserServicesHost(ConfigurationManager.AppSettings["ServiceHost"], int.Parse(ConfigurationManager.AppSettings["UserServicePort"]));
            var userServiceHostThread = new Thread(userServiceHost.Initialize);
            userServiceHostThread.Start();

            Console.ReadLine();



        }

    }
}
