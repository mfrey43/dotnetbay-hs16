using System;
using System.Threading.Tasks;
using DotNetBay.SignalR.Hubs;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DotNetBay.WebApp.Startup))]

namespace DotNetBay.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {          // Configure Web API for self-host.           
            AppDomain.CurrentDomain.Load(typeof(AuctionsHub).Assembly.FullName);
            app.MapSignalR();
        }
    }
}
