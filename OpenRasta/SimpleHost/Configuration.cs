using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRasta.Configuration;

namespace SimpleHost
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                HelloWorldHandler.Configure();
            }
        }
    }
}
