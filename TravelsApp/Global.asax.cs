﻿using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TravelsApp.BLL.Util;
using TravelsApp.Models;
using TravelsApp.Util;

namespace TravelsApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule unitOfWorkModule = new Util.TravelServiceModule();
            NinjectModule travelService = new BLL.Util.UnitOfWorkModule();
            var kernel = new StandardKernel(unitOfWorkModule, travelService);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
