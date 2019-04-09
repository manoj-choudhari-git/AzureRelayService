using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfContracts;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("STARTING: Math Service Client");
            Console.WriteLine("======================================================");

            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.AutoDetect;
            var cf = new ChannelFactory<IMathServiceChannel>("math");

            Console.WriteLine();
            Console.WriteLine("Sending Add request with parameters 4 and 5");
            using (var ch = cf.CreateChannel())
            {
                Console.WriteLine("Result = " + ch.Add(4, 5));
            }

            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine("Sending Subtract request with parameters 100 and 5");
            using (var ch = cf.CreateChannel())
            {
                Console.WriteLine("Result = " + ch.Subtract(100, 5));
            }

            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to exit.");
            Console.ReadLine();
        }
    }
}
