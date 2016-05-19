using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Repository;
using MyCarsale.WebHost.DTO;
using AutoMapper;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.Service;
using Newtonsoft.Json.Linq;

namespace MyCarsale.WebHost.Controllers
{
    public class HomeController : ApiController
    {

        private IUnitOfWork unit;
        private ConvertToDTO convertToDto ;



        /// <summary>
        /// HomeController
        /// </summary>
        public HomeController(IUnitOfWork unit)
        {
            this.unit = unit;
            convertToDto = new ConvertToDTO();
        }



        /// <summary>
        /// Get data to provide search criteria
        /// </summary>
        /// <returns></returns>
        
        public IHttpActionResult Get()
        {
            #region ToDelete
            //pricelistDto = (from act in carsearchinfo.PriceList select new DTO.PriceDto { PriceRange = new DTO.RangeDto { minvalue = act.PriceRange.minvalue } }).ToList();

            // pricelistDto = (from act in carsearchinfo.PriceList select new DTO.PriceDto { PriceRange = new DTO.RangeDto { minvalue = act.PriceRange.minvalue } }).ToList();
            //demodto = (from a in carsearchinfo select new CarSearchDto { PriceList = (from ab in carsearchinfo select new PriceDto { ran  }
            #endregion
            var carsearchinfo = unit.Car.CarSearch;
            
            var response = carsearchinfo.To<CarSearchDto>();

            return Ok(response);
        }


        [HttpPost]
        public IHttpActionResult CarSearchResult([FromBody]CarInfoDto carSrcReq)
        {
            CarInfoDto carSearchReqDTO = new CarInfoDto();

            carSearchReqDTO = (CarInfoDto) carSrcReq;

            var carSearchReq = carSearchReqDTO.To<CarInfo>();

            var car = unit.Car.CarSearchResult(carSearchReq);

            var response = car.To<CarCollection>();

            return Ok(car);
        }

        [HttpDelete]
        public IHttpActionResult Del(int id)
        {

            //var carCollection = carCollectionDto.To<CarCollection>();

            unit.Car.DeleteCarDetails(id);

            return Ok();
        }

    }
}
