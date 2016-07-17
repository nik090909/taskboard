﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;

namespace TaskBoard.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IKernel kernel = new StandardKernel();
            //bind
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
