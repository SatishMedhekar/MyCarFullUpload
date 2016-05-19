using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

using MyCarsale.WebHost.Infrastructure;

namespace MyCarsale.WebHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            log4net.Config.XmlConfigurator.Configure();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: null
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiAll",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            config.DependencyResolver = new ServiceResolver();

            config.MessageHandlers.Add(new BasicAuthenticationHandler(new CustomPrincipalProvider()));

            //Comment this line incase you do not want application wise security
            //config.Filters.Add(new System.Web.Http.AuthorizeAttribute());

        }
    }
}
