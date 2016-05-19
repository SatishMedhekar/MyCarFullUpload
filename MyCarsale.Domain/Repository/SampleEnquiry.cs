using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;
using System.Web.Script.Serialization;
using System.Runtime.Caching;

namespace MyCarsale.Domain.Repository
{
    public class SampleEnquiry : IEnquiry
    {


        List<Enquiry> enquiry;
        MemoryCache memoryCache = MemoryCache.Default;

        public SampleEnquiry()
        {
            var customer = new Customer
            {
                CustomerName = new PersonalInfo
                {
                    FName = "Andrew",
                    LName = "Force",
                    Email = "andrew@yahoo.com",
                    PhoneInfo = new ContactInfo { Mobile = 0423945876, Phone = 0236845598, WorkPhone = 0252680045, AfterHourContact = 0236845598 },
                },
               
            };

            enquiry = new List<Enquiry>
            { new Enquiry { ID=1, CustomerDetail = customer,
                           
                            Comment = "Hi, I am interested in this model.  Could you please get your saleperson to contact me" } };
        }




        public List<Enquiry> GetEnquiryReport(int carID)
        {
            return enquiry.AsQueryable().Where(x => x.ID == carID).ToList();
        }


        public EnquiryCollection GetEnquiryList()
        {
            EnquiryCollection enqcol = new EnquiryCollection();

            var enqlst = GetCacheEnquiryCollection();
            if (enqlst.Enquiries != null)
            {
                enqcol.Enquiries = enqlst.Enquiries;
                return enqcol;
            }
            return enqcol;

            }



        public void SubmitEnquiry(Enquiry CustomerInquiry)
        {

            EnquiryCollection enquirycollection = new EnquiryCollection();
            enquirycollection.Enquiries = new List<Enquiry>();



            var enqcollection = GetCacheEnquiryCollection();

            if (enqcollection.Enquiries != null)
            { enquirycollection = enqcollection; }




            Enquiry enquiry = new Enquiry
            {
                ID = CustomerInquiry.ID,
                CustomerDetail = new Customer
                {
                    ID = 1,
                    CustomerName =new PersonalInfo
                                  {
                                  Email = CustomerInquiry.CustomerDetail.CustomerName.Email,
                                  FName = CustomerInquiry.CustomerDetail.CustomerName.FName,
                                  LName = CustomerInquiry.CustomerDetail.CustomerName.LName,
                                  PhoneInfo = new ContactInfo
                                  {
                                  AfterHourContact = 0,
                                  Mobile = CustomerInquiry.CustomerDetail.CustomerName.PhoneInfo.Mobile,
                                  Phone = 0,
                                  WorkPhone = 0
                                  }
                                  }
                }, CarId = CustomerInquiry.CarId,
                 Comment = CustomerInquiry.Comment
            };
                                
            


            

            enquirycollection.Enquiries.Add(enquiry);

            AddToCacheEnquiryCollection(enquirycollection);


            enquirycollection = GetCacheEnquiryCollection();

        }



        /// <summary>
        /// Store the enquiry details in Cache
        /// </summary>
        /// <param name="carcollection"></param>
        public void AddToCacheEnquiryCollection(EnquiryCollection CustomerInquiry)
        {

            var javascriptserializer = new JavaScriptSerializer();
            DateTimeOffset absExpiration = DateTimeOffset.UtcNow.AddHours(1);

            string enquirySerialize = javascriptserializer.Serialize(CustomerInquiry);
            memoryCache.Remove("enquirycollection");
            memoryCache.Add("enquirycollection", enquirySerialize, absExpiration);


        }




        /// <summary>
        /// Retrive Car collection details from Cache
        /// </summary>
        /// <returns></returns>
        private EnquiryCollection GetCacheEnquiryCollection()
        {
            EnquiryCollection enquirycoll = new EnquiryCollection();
            var javascriptserializer = new JavaScriptSerializer();

            var strCarcol = memoryCache.Get("enquirycollection");

            if (strCarcol != null)
            {
                enquirycoll = javascriptserializer.Deserialize<EnquiryCollection>(strCarcol.ToString());
                
            }
            return enquirycoll;
        }




    }



}
