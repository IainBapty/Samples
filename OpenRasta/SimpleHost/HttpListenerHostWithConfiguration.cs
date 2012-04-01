using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRasta.Hosting.HttpListener;
using OpenRasta.Configuration;
using OpenRasta.DI;

namespace SimpleHost
{
    public class HttpListenerHostWithConfiguration : HttpListenerHost
    {
        readonly IConfigurationSource _configurationSource;

        public HttpListenerHostWithConfiguration(IConfigurationSource configurationSource)
        {
            _configurationSource = configurationSource;
        }

        public override bool ConfigureRootDependencies(IDependencyResolver resolver)
        {
            bool result = base.ConfigureRootDependencies(resolver);
            if (result && _configurationSource != null)
            {
                resolver.AddDependencyInstance<IConfigurationSource>(_configurationSource);
            }

            return result;
        }
    }
}
