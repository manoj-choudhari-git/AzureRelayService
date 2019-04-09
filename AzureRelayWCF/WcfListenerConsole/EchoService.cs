using System;
using System.Collections.Generic;
using System.Text;
using WcfContracts;
////using WcfListenerConsole.Contracts;

namespace WcfListenerConsole
{
    public class MathService : IMathService
    {
        public int Add(int first, int second)
        {
            Console.WriteLine($"Received add request for {first} and {second}");
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            Console.WriteLine($"Received subtract request for {first} and {second}");
            return first - second;
        }
    }
}
