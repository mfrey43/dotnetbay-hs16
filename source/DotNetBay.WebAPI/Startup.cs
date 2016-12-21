using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DotNetBay.Core;
using DotNetBay.Data.EF;
using DotNetBay.Interfaces;
using Microsoft.Practices.Unity;

namespace DotNetBay.WebAPI
{
    public class Startup
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IMainRepository, EFMainRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuctionService, AuctionService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMemberService, SimpleMemberService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new WebApiUnityContainer(container);
        }
    }
}