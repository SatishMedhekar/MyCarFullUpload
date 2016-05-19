using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Integration;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Threading.Tasks;
using System.Reflection;

namespace MyCarSale.API
{
    public static class AutofacWebAPI
    {
        /// <summary>
        /// This method is called by Hosting layer.  This inturns calls the second 
        /// initialize method by providing IContainer instance through RegisterServices
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize (HttpConfiguration config)
        {
            Initialize(config, RetisterServices(new ContainerBuilder()));
        }


        /// <summary>
        /// This is called by integration tests by providing IContainer instance
        /// </summary>
        /// <param name="config"></param>
        /// <param name="container"></param>
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            //Passes HttpConfiguration instance Dependency Resolver property
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// This is the method to register the dependencies
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IContainer RetisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            return builder.Build();
        }
    }
}
