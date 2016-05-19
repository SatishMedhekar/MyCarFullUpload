using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Client.Infrastructure;
//using MyCarsale.Client.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;

namespace MyCarsale.Client
{

     public class MyCarSaleClient
    {
        private readonly HttpClient client;
        private HttpResponseMessage response;


        public MyCarSaleClient()
        {
            client = new HttpClient(new AuthenticationHandler("fanier", "supersecretpassword"));

           //client.BaseAddress = new Uri("http://localhost:57047/");
            client.BaseAddress = new Uri("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com");


        }


        public CarSearchInfo GetFillSearchCriteria()
        {
            response = client.GetAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Home").Result;
            //response = client.GetAsync("/api/Home").Result;

            if (response.IsSuccessStatusCode)
            {
                //var result = response.Content.ReadAsAsync<JToken>().Result;

                CarSearchInfo CarSearchResp =   response.Content.ReadAsAsync<CarSearchInfo>().Result;

                return CarSearchResp;
                
                
            }

            return null;
        }


        public CarCollection GetCarSearchResult(CarInfo carinfo)
        {
           
            response = client.PostAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Home", carinfo).Result;

            if (response.IsSuccessStatusCode)
            {
                CarCollection carcollection = response.Content.ReadAsAsync<CarCollection>().Result;
                return carcollection;
            }
            return null;
        }



        


        public void PostEnquiry(Enquiry enquiry)
        {
            

            response = client.PostAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Enquiry", enquiry).Result;

            if (response.IsSuccessStatusCode)
            {
                var resp = response.Content.ReadAsAsync<CarCollection>().Result;
               
            }
          
        }



        public Car GetSingleCar(Car car)
        {
            

            response = client.PostAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/CarMaintain", car).Result;

            if (response.IsSuccessStatusCode)
            {
                Car carresponse = response.Content.ReadAsAsync<Car>().Result;
                return carresponse;
            }
            return null;

        }


        public void DeleteCar(Car car )
        {
           

            response = client.PostAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/CarDelete", car).Result;
            
        }



        public EnquiryCollection GetEnquires()
        {
            response = client.GetAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Enquiry").Result;

            if (response.IsSuccessStatusCode)
            {
               

                EnquiryCollection enquiries = response.Content.ReadAsAsync<EnquiryCollection>().Result;

                return enquiries;


            }

               return null;
        }



        public bool PostCar(CustomCar carRequest)

        {
            Car car = carRequest.car;
           

            
            response = client.PostAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Car", carRequest.car).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
           
        }



        public bool PutCar(CustomCar carRequest)

        {
            Car car = carRequest.car;


            ;
            response = client.PutAsJsonAsync("http://mycarsalewebhost-dev.us-west-2.elasticbeanstalk.com/api/Car", carRequest.car).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }




        //ToDo : Currently bug.  Not working with HttpDelete.  Substitute method DeleteCar in use
        //public void DeleteCar(int id)
        //{
        //    MyCarSaleClient my = new MyCarSaleClient();

        //     response = client.DeleteAsync ("/api/Car/1").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var resp = response.Content.ReadAsAsync<CarCollection>().Result;

        //    }

        //}


        public void PutCar(Car car)
        {

        }


    }
}
