using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCarsale.Client;
using MyCarSale.App.Service;


namespace MyCarSale.App.Controllers
{
    public class EnquiryController : Controller
    {

        MyCarSaleClient client = new MyCarSaleClient();

        service ser = new service();
        public EnquiryController()
        {
            
        }

        public ActionResult Index()
        {
            CarCollection car = new CarCollection();
            
            CarCollection carcollection = ser.InitialiseCarList((CarCollection)TempData["result"]);
            TempData["result"] = carcollection;
            return View(carcollection);
        }

       


        public ActionResult PostEnquiry(int id)
        {
            Enquiry enq = new Enquiry();
            enq.CarId = id;
            return PartialView(enq);
        }


        [HttpPost]
        public ActionResult PostEnquiry(Enquiry enquiry)
        {
            client.PostEnquiry(enquiry);
            CarCollection carcollection = (CarCollection)TempData["result"];
            ser.ProcessOrder(enquiry);
            return RedirectToAction("Index");
        }



        public FileContentResult GetImage(Car car)
        {
            if (car.imageData == null)
                return null;

              return File(car.imageData, "jpg");
            

            
        }
    }
}