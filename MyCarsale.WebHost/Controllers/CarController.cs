using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.DTO;
using MyCarsale.WebHost.Service;
using System.Linq;

using System.Collections.Generic;

namespace MyCarsale.WebHost.Controllers
{
    public class CarController : ApiController
    {

        private IUnitOfWork unit;
        private ConvertToDTO convertToDto;



        /// <summary>
        /// Constructor : IOC injection
        /// </summary>
        public CarController(IUnitOfWork unit)
        {
            this.unit = unit;
            convertToDto = new ConvertToDTO();
        }



        /// <summary>
        /// submit request to add the carinformation to database
        /// </summary>
        /// <param name="enquiryRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] CarDto carRequestDto)
        {
            var carRequest = carRequestDto.To<Car>();

            //var carCollection = carCollectionDto.To<CarCollection>();

            // var car = convertToDto.GetEnquiryeDto(enquiryRequestDto);

            unit.Car.SaveCarDetails(carRequest);

            //var response = carCollectionResponse.To<CarCollectionDto>();

            return Ok();
        }



        /// <summary>
        /// submit request to add the carinformation to database
        /// </summary>
        /// <param name="enquiryRequestDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put([FromBody] CarDto carRequestDto)
        {
            var carRequest = carRequestDto.To<Car>();

            //var carCollection = carCollectionDto.To<CarCollection>();

            // var car = convertToDto.GetEnquiryeDto(enquiryRequestDto);

            unit.Car.UpdateCarDetails(carRequest);

            //var response = carCollectionResponse.To<CarCollectionDto>();

            return Ok();
        }




        /// <summary>
        /// Delete car request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carCollectionDto"></param>
        /// <returns></returns>
        [HttpDelete]
        public void Delete([FromUri] int id)
        {

            //var carCollection = carCollectionDto.To<CarCollection>();

            unit.Car.DeleteCarDetails(System.Convert.ToInt32(id));

           
        }



        [HttpGet]
        public IHttpActionResult Get(CarInfoDto CarInfo)
        {
            var CInfo = CarInfo.To<CarInfo>();
            var carcollection = unit.Car.CarSearchResult(CInfo);
            
            var response = carcollection.To<CarCollection>();

            return Ok(response);


        }




    }
}
