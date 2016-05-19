using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCarsale.Client;
using System.IO;
using MyCarSale.App.Service;

namespace MyCarSale.App.Controllers
{
    public class DealerController : Controller
    {

        MyCarSaleClient client = new MyCarSaleClient();
        service ser = new service();

        // GET: Dealer
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]   
        public ActionResult Login(int id)
        {
            string message="success";
            if (Request.IsAjaxRequest())
            {
                return RedirectToAction("Details", "Dealer");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }



        public ActionResult Details()
        {
            CarCollection carcollection = new CarCollection();
            var carinfo = new CarInfo();
            carinfo.intKilometer = 1200;
            carcollection = client.GetCarSearchResult(carinfo);
            var totalEnquiry = client.GetEnquires();

            foreach (Car c in carcollection.cars)
            {
                c.TotalInquiry = totalEnquiry.Enquiries.Where(a=>a.CarId==c.ID).Select(i => i.ID).Count();
            }

            return View(carcollection);
        }



        [HttpPost]
        public ActionResult DelCar(int id)
        {
            Car car = new Car { ID = id };

            client.DeleteCar(car);
            return RedirectToAction("Details");
        }





        public ActionResult Edit(int id)
        {
            
            CustomCar customcar = new CustomCar();
            

            Car carInitial = new Car();
            Car car = new Car();

            
            Car carresp = new Car { ID =id };
            car = client.GetSingleCar(carresp);

            car = ser.InitialiseCar(car);

            var searchCriteria = client.GetFillSearchCriteria();

            customcar.car = car;
            customcar.Dropdowncollection = searchCriteria;

            

            return View(customcar);
        }


        [HttpPost]
        public ActionResult Edit(CustomCar customcar)
        {
            Car car = new Car();

            car = customcar.car;
            car = ser.InitialiseCar(car);

          
            var searchCriteria = client.GetFillSearchCriteria();

            customcar.car = car;
            customcar.Dropdowncollection = searchCriteria;

            client.PutCar(customcar);

            return RedirectToAction("Details");

        }



        public ActionResult ADD()
        {
            

            var searchCriteria = client.GetFillSearchCriteria();

            CustomCar customcar = new CustomCar();
            customcar.Dropdowncollection = searchCriteria;

            Car carInitial = new Car();
            Car car = new Car ();

            carInitial.CarSepcificInfo = new CarInfo
            {
                CarBadge = searchCriteria.CarMakeModelList.CarBadgeList.Where(x => x.id == 1).FirstOrDefault(),
                CarMake = searchCriteria.CarMakeModelList.CarMakeList.Where(x => x.id == 1).FirstOrDefault(),
                CarModel = searchCriteria.CarMakeModelList.CarModelList.Where(x => x.id == 1).FirstOrDefault(),
                CarSeries = searchCriteria.CarMakeModelList.CarSeriesList.Where(x => x.id == 1).FirstOrDefault(),
                CarLocation = new Location { City = searchCriteria.CarLocation.Where(x => x.CityId == 1).FirstOrDefault() }
            };


            carInitial.CarDetailInfor = new CarDetailSepification
            {
                CarEngine = new Engine
                {
                    EngineClinders =  new Cylinders { Id = 0, CylinderType = "" },
                    EngineDrive = new Drive { id = 0, DriveType=""},
                    EngineFuel = new Fuel { Id=0, FuelType=""},
                    EngineInduction = new Induction { Id=0, InductionType=""},
                    EnginePower = new  Power { Id = 0,  PowerRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EngineSize = new Size {  Id = 0, SizeRange = new Range { minvalue=0, maxvalue=0} },
                    EngineTowing =  new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } }
                   
                },
                CarExtra = new Extra
                {
                    ExtraAncap = new Ancap { Id=0, AncapType=""},
                    ExtraGreenRating = new GreenRating { Id=0, GreenRatingType=""},
                    ExtraPplate = new Pplate { Id=0, state= new State {  StateID=0, StateName=""} }
                },
                CarStyle = new Style
                {
                    StyleBody = new Body { Id=0, BodyType=""},
                    StyleColor = new Colorcode { Id=0, Color=""},
                    StyleDoor = new Door { Id=0, DoorType=""},
                    StyleSeats = new Seats { Id = 0, SeatRange = new Range { maxvalue = 0, minvalue = 0 } }


                }
            };
            



            if (TempData["carphoto"] == null)
            {
                car.imageData = imgtoByteArray();
            }
            else
            {
                //Car cphoto = (Car)TempData["carphoto"];
                //car.imageData = cphoto.imageData;
                //car.Photo = cphoto.Photo;
                //car.photoname = cphoto.photoname;

                car = (Car)TempData["carphoto"];
            }

            car.CarDetailInfor = carInitial.CarDetailInfor;
            car.CarSepcificInfo = carInitial.CarSepcificInfo;

            TempData["carphoto"] = car;
            customcar.car = car;
            return View(customcar);
        }


        [HttpPost]
        public ActionResult ADD(CustomCar customcar)
        {
            Car car = new Car();
            Car photocar = new Car();
            photocar = (Car)(TempData["carphoto"]);

            car = customcar.car;
            car.imageData = photocar.imageData;
            car.imagesize = photocar.imagesize;
            car.photoname = photocar.photoname;

            
            bool result = client.PostCar(customcar);
            return RedirectToAction("Details");
        }


        public ActionResult Upload()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Upload(Car car)
        {

            if (car.Photo.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }


            car.imagesize = car.Photo.ContentLength;
            car.photoname = car.ID.ToString() + "_Photo";
            byte[] data = new byte[car.Photo.ContentLength];
            car.Photo.InputStream.Read(data, 0, car.Photo.ContentLength);
            car.imageData = data;

            Session["Photo"] = car;
            TempData["carphoto"] = car;

            return RedirectToAction("ADD");
        }




        public ActionResult EditUpload()
        {

            return View();
        }


        [HttpPost]
        public ActionResult EditUpload(Car car)
        {

            if (car.Photo.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }


            car.imagesize = car.Photo.ContentLength;
            car.photoname = car.ID.ToString() + "_Photo";
            byte[] data = new byte[car.Photo.ContentLength];
            car.Photo.InputStream.Read(data, 0, car.Photo.ContentLength);
            car.imageData = data;

            Session["Photo"] = car;
            TempData["carphoto"] = car;

            return RedirectToAction("Edit");
        }



        public ActionResult GetEnquiryDetail(int id =0)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetEnquiryDetail()
        {

            return RedirectToAction("Details");
        }



        public byte[] imgtoByteArray()
        {
            using (MemoryStream mstream = new MemoryStream())
            {
                System.Drawing.Image img = Properties.Resources.Noimages; //System.Drawing.Image.FromFile(@"C:\Satish\Practice\HandsOn\MyCarsale\MyCarSale.App\Images\Noimages.jpg");
                img.Save(mstream, img.RawFormat);
                return mstream.ToArray();
            }

        }
    }
}