using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using System.Web.Http;

namespace MyCarsale.WebHost.Infrastructure
{
    public class ServiceResolver : IDependencyResolver
    {
        static readonly IUnitOfWork carsale = new DataStore();
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.BaseType == typeof(ApiController))
                return Activator.CreateInstance(serviceType, carsale);
            return null;
        }


        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}