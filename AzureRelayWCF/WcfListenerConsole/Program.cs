using Microsoft.ServiceBus;
using System;
using System.ServiceModel;

namespace WcfListenerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.AutoDetect;

            // Create the service host reading the configuration.
            ServiceHost host = new ServiceHost(typeof(MathService));

            // Open the service.
            host.Open();

            Console.WriteLine("======================================================");
            Console.WriteLine("STARTING: Math Service Host");
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("======================================================");
            Console.WriteLine("All Available Endpoints:");
            Console.WriteLine();
            foreach (var item in host.Description.Endpoints)
            {
                Console.WriteLine();
                Console.WriteLine($"Endpoint: {item.Name}");
                Console.WriteLine($" -> Endpoint : {item.Address.Uri}");
                Console.WriteLine($" -> Binding : {item.Binding.Name}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();

            // Close the service.
            host.Close();

        }
    }
}
