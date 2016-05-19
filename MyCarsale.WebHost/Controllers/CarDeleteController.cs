using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.DTO;
using MyCarsale.WebHost.Service;
using System.Web.Http;

namespace MyCarsale.WebHost.Controllers
{
    public class CarDeleteController : ApiController
    {
        private IUnitOfWork unit;
        private ConvertToDTO convertToDto;


        public CarDeleteController(IUnitOfWork unit)
        {
            this.unit = unit;
            convertToDto = new ConvertToDTO();
        }
        

        /// <summary>
        /// Delete car request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carCollectionDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Del([FromBody] Car car)
        {

            //var carCollection = carCollectionDto.To<CarCollection>();

            unit.Car.DeleteCarDetails(car.ID);

            return Ok();
        }

    }
}
