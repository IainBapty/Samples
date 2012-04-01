using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Service");

            using (var service = new SimpleService())
            {
                service.Start();
                Console.WriteLine("Service Started");
                Console.WriteLine("Browse to: http://localhost:8090/simple/hello");

                Console.ReadLine();
            }
        }
    }
}
