using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Jcars.Business.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Jcars.Business.Services.CarService;

namespace Jcars
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<JcarsDbContext, JcarsDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<User>>(() => new UserStore<User>(container.GetInstance<JcarsDbContext>()), Lifestyle.Scoped);
            container.Register(() => new UserManager<User>(container.GetInstance<IUserStore<User>>()), Lifestyle.Scoped);
            container.Register<ICarService, CarService>(Lifestyle.Scoped);


            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
