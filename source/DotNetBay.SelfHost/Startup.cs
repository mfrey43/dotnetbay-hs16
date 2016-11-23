using System;
using System.Threading.Tasks;
using System.Web.Http;
using DotNetBay.Health.Owin;
using DotNetBay.WebAPI.Controllers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DotNetBay.SelfHost.Startup))]

namespace DotNetBay.SelfHost
{
    public class Startup
    {
        Type apiControllerType = typeof(APIController);

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            //  Enable attribute based routing
            config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);
        }
    }
}
