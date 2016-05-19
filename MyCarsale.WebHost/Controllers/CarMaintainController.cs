using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.DTO;
using MyCarsale.WebHost.Service;


namespace MyCarsale.WebHost.Controllers
{
    public class CarMaintainController : ApiController
    {

        private IUnitOfWork unit;
        private ConvertToDTO convertToDto;


        /// <summary>
        /// Constructor : IOC injection
        /// </summary>
        public CarMaintainController(IUnitOfWork unit)
        {
            this.unit = unit;
            convertToDto = new ConvertToDTO();
        }

        



        [HttpPost]
        public IHttpActionResult GetSingleCar(CarDto car)
        {
            var carreq = car.To<Car>();
            var carresult = unit.Car.CarSearchResultSingle(carreq);

            var response = carresult.To<Car>();

            return Ok(response);


        }

    }
}
