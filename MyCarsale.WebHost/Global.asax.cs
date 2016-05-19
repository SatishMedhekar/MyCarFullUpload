using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyCarsale.WebHost.Infrastructure;
using System.Web.SessionState;

namespace MyCarsale.WebHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            var config = GlobalConfiguration.Configuration;

            /*
            RouteConfig.RegisterRoutes(config);
            WebAPIConfig.Configure(config);
            AutofacWebAPI.Initialize(config);
            */
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapsConfig.Register();
            GlobalConfiguration.Configuration.Filters.Add(new LoggerAttribute());

            MyCarsale.Domain.Repository.SetFakeCarRepository.setCarFakeData();
        }


        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }
    }
}
