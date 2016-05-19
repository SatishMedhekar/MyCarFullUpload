using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCarsale.Client;
using MyCarSale.App.Service;


namespace MyCarSale.App.Controllers
{
    public class HomeController : Controller
    {
        
        MyCarSaleClient client = new MyCarSaleClient();
        CarSearchInfo carsearchinfo = new CarSearchInfo();
        service ser = new service();


       [HttpGet]
        public ActionResult Index()
        {
            CustomCar custcar = new CustomCar();
            custcar.car = ser.InitialiseCar();
            custcar.Dropdowncollection = client.GetFillSearchCriteria();
            custcar.car = ser.InitialiseCar(custcar.car);
            return View(custcar);
        }


        
        [HttpPost]
        public ActionResult Index(CustomCar carsearchinfo )
        {

            //if (carsearchinfo.Dropdowncollection.PriceList.Select(x=>x.PriceRange.maxvalue).FirstOrDefault() < 
            //            carsearchinfo.Dropdowncollection.PriceList.Select(x => x.PriceRange.maxvalue).FirstOrDefault())
            //{
            //    ModelState.AddModelError("priceerror", "Max price should be greater that Min price");
            //    carsearchinfo.Dropdowncollection = client.GetFillSearchCriteria();
            //    return View (carsearchinfo);
            //}



            var carinfo = new CarInfo();
            carinfo.intKilometer = 1200;
           var carcollection = client.GetCarSearchResult(carinfo);
            TempData["result"] = carcollection;
            //return PartialView (carcollection);
            //return RedirectToAction("Enquiry");

            return RedirectToAction("Index", "Enquiry", new { carcol = carcollection });
        }
    }


        
    }
