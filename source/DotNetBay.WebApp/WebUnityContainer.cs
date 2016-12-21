using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.EF;
using DotNetBay.Interfaces;
using Microsoft.Practices.Unity;

namespace DotNetBay.WebApp
{
    public class WebUnityContainer : UnityContainer
    {
        public WebUnityContainer()
        {
            this.RegisterType<IMainRepository, EFMainRepository>(new HierarchicalLifetimeManager());
            this.RegisterType<IAuctionService, AuctionService>(new HierarchicalLifetimeManager());
            this.RegisterType<IMemberService, SimpleMemberService>(new HierarchicalLifetimeManager());
        }
    }
}