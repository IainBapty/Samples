using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRasta.Configuration;

namespace SimpleHost
{
    public class HelloWorldHandler
    {
        public static void Configure()
        {
            ResourceSpace.Has.ResourcesOfType<string>()
            .AtUri("/hello")
            .HandledBy<HelloWorldHandler>();
        }

        public string GetHelloWorld()
        {
            return "Hello.World!";
        }
    }
}
