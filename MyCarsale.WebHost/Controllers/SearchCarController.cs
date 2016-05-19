using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.WebHost.DTO;
using MyCarsale.Domain.Models;


namespace MyCarsale.WebHost.Controllers
{
    
    public class SearchCarController : ApiController
    {
        private IUnitOfWork unit;

        public SearchCarController()
        {
            unit = new DataStore();
        }


        public IHttpActionResult Get(CarInfoDto CarInfo)
        {
            var CInfo= CarInfo.To<CarInfo>();
            var car = unit.Car.CarSearchResult(CInfo);
            
            var response = car.To<Car>();

            return Ok(response);

        }


    }
}
