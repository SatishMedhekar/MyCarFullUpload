using System.Web.Http;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Models;
using MyCarsale.WebHost.DTO;
using MyCarsale.WebHost.Service;


namespace MyCarsale.WebHost.Controllers
{
    
    /// <summary>
    /// Use this API to Submit Enquiry
    /// </summary>
    public class EnquiryController : ApiController
    {

        private IUnitOfWork unit;
        private ConvertToDTO convertToDto;

        /// <summary>
        /// Constructor : IOC injection
        /// </summary>
        public EnquiryController(IUnitOfWork unit)
        {
            this.unit = unit;
                        
            // var car = convertToDto.GetEnquiryeDto(enquiryRequestDto);
        }



        /// <summary>
        /// Post action is used to submit request.  Enquiry is hold in session at MVC but 
        /// this round trip is to demostrate case when database is in used.
        /// </summary>
        /// <param name="enquiryRequestDto"></param>
        /// <returns>EnquiryDto</returns>
        public IHttpActionResult Post([FromBody]EnquiryDto enquiryRequestDto)
        {
            var enquiryRequest = enquiryRequestDto.To<Enquiry>();
                       
             unit.CarEnquiry.SubmitEnquiry(enquiryRequest);

            

            return Ok();
        }



        public IHttpActionResult Get()
        {
            var enquiries = unit.CarEnquiry.GetEnquiryList();

            var response = enquiries.To<EnquiryCollectionDto>();

            return Ok(response);



            return Ok();
        }

    }
}
