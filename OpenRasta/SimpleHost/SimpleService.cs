using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenRasta.Hosting.HttpListener;
using OpenRasta.Configuration;
using OpenRasta.DI;

namespace SimpleHost
{
    public class SimpleService : IDisposable
    {
        readonly string _vdir;
        HttpListenerHostWithConfiguration _host;

        public SimpleService()
        {
            Prefix = "http://+:8090/simple/";
        }

        public string Prefix { get; set; }

        public void Start()
        {
            var configurator = new Configuration();
            _host = new HttpListenerHostWithConfiguration(configurator);

            var vdir = Prefix.Substring(Prefix.IndexOf("/", Prefix.IndexOf("://") + 3));
            
            _host.Initialize(new[] { Prefix }, vdir, null);

            _host.StartListening();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        void Dispose(bool disposing)
        {
            if (disposing && _host != null)
                _host.Close();
        }
    }
}
