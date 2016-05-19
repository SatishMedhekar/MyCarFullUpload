using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Caching;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MyCarsale.Domain.Repository
{
    public partial class SampleCarRepository : ICarRepository
    {



        MemoryCache memoryCache = MemoryCache.Default;

        public SampleCarRepository()
        {



            #region Not required Mark for deletion
            //    CarList = new List<Car> {
            //    new Car
            //    {
            //        ID = 1,
            //        CarSepcificInfo = new CarInfo
            //        {
            //            CarMake = getMakes().Where(x => x.id == 1).FirstOrDefault(),
            //            CarModel = getModels().Where(x => x.id == 1).FirstOrDefault(),
            //            CarBadge = getBadges().Where(x => x.id == 1).FirstOrDefault(),
            //            CarSeries = getSerieses().Where(x => x.id == 1).FirstOrDefault(),
            //            CarPrice = 35000,
            //            ManufactureYear = 2013,
            //            intKilometer = 40000,
            //            KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
            //            CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
            //        },
            //        CarDetailInfor = null
            //    },
            //    new Car
            //    {
            //        ID = 2,
            //        CarSepcificInfo = new CarInfo
            //        {
            //            CarMake = getMakes().Where(x => x.id == 2).FirstOrDefault(),
            //            CarModel = getModels().Where(x => x.id == 4).FirstOrDefault(),
            //            CarBadge = getBadges().Where(x => x.id == 4).FirstOrDefault(),
            //            CarSeries = getSerieses().Where(x => x.id == 4).FirstOrDefault(),
            //            CarPrice = 15000,
            //            ManufactureYear = 2009,
            //            intKilometer = 50000,
            //            KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
            //            CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
            //        },
            //        CarDetailInfor = null
            //    },
            //     new Car
            //    {
            //        ID = 3,
            //        CarSepcificInfo = new CarInfo
            //        {
            //            CarMake = getMakes().Where(x => x.id == 3).FirstOrDefault(),
            //            CarModel = getModels().Where(x => x.id == 7).FirstOrDefault(),
            //            CarBadge = getBadges().Where(x => x.id == 7).FirstOrDefault(),
            //            CarSeries = getSerieses().Where(x => x.id == 7).FirstOrDefault(),
            //            CarPrice = 50000,
            //            ManufactureYear = 2015,
            //            intKilometer = 30000,
            //            KilometerRange = getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
            //            CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
            //        },
            //        CarDetailInfor = null
            //    }


            //};

            #endregion
        }







        CarSearchInfo ICarRepository.CarSearch
        {
            get
            {
                return CarInfo();
            }
        }







        /// <summary>
        /// Fake car repository
        /// </summary>
        /// <param name="carrequest"></param>
        /// <returns></returns>
        public CarCollection CarSearchResult(CarInfo carrequest)
        {
            CarCollection carCollectionRepository = GetCacheCarCollection();

            List<Car> carlist = (from lst in carCollectionRepository.cars
                                 where ((carrequest.CarMake == null || lst.CarSepcificInfo.CarBadge.id == carrequest.CarBadge.id)

                                /*Model*/         || (carrequest.CarModel == null || lst.CarSepcificInfo.CarModel.id == carrequest.CarModel.id)
                                /*Badge*/         || (carrequest.CarBadge == null || lst.CarSepcificInfo.CarBadge.id == carrequest.CarBadge.id)
                               /*Series*/         || (carrequest.CarSeries == null || lst.CarSepcificInfo.CarSeries.id == carrequest.CarSeries.id)
                               /*Price*/          || ((carrequest.PriceRange == null || (carrequest.PriceRange.PriceRange.minvalue == 0 && carrequest.PriceRange.PriceRange.maxvalue == 0))
                                                      || (lst.CarSepcificInfo.CarPrice >= carrequest.PriceRange.PriceRange.minvalue && lst.CarSepcificInfo.CarPrice <= carrequest.PriceRange.PriceRange.maxvalue))
                              /*year*/            || ((carrequest.YearRange.YearRange == null || (carrequest.YearRange.YearRange.minvalue == 0 && carrequest.YearRange.YearRange.maxvalue == 0))
                                                      || (lst.CarSepcificInfo.ManufactureYear >= carrequest.YearRange.YearRange.minvalue && lst.CarSepcificInfo.ManufactureYear <= carrequest.YearRange.YearRange.maxvalue))
                             /*KM*/               || ((carrequest.KilometerRange.KilometerRange == null || (carrequest.KilometerRange.KilometerRange.minvalue == 0 && carrequest.KilometerRange.KilometerRange.maxvalue == 0))
                                                      || (lst.CarSepcificInfo.intKilometer >= carrequest.KilometerRange.KilometerRange.minvalue && lst.CarSepcificInfo.intKilometer <= carrequest.KilometerRange.KilometerRange.maxvalue))
                             /*Location*/         || (carrequest.CarLocation.city == null || lst.CarSepcificInfo.CarLocation.city.CityId == carrequest.CarLocation.city.CityId)
                                        )
                                 select new Car
                                 {
                                     ID = lst.ID,
                                     imageData = lst.imageData,
                                     carType = lst.carType == null ? null : geCarTypeList().Where(x => x.carTypeID == lst.carType.carTypeID).FirstOrDefault(),
                                     CarSepcificInfo = lst.CarSepcificInfo == null ? null : new CarInfo
                                     {
                                         CarMake = lst.CarSepcificInfo.CarMake == null ? null : getMakes().Where(x => x.id == lst.CarSepcificInfo.CarMake.id).FirstOrDefault(),
                                         CarModel = lst.CarSepcificInfo.CarModel == null ? null : getModels().Where(x => x.id == lst.CarSepcificInfo.CarModel.id).FirstOrDefault(),
                                         CarBadge = lst.CarSepcificInfo.CarBadge == null ? null : getBadges().Where(x => x.id == lst.CarSepcificInfo.CarBadge.id).FirstOrDefault(),
                                         CarSeries = lst.CarSepcificInfo.CarSeries == null ? null : getSerieses().Where(x => x.id == lst.CarSepcificInfo.CarSeries.id).FirstOrDefault(),
                                         CarPrice = lst.CarSepcificInfo.CarPrice,
                                         ManufactureYear = lst.CarSepcificInfo.ManufactureYear,
                                         intKilometer = lst.CarSepcificInfo.intKilometer,
                                         CarLocation = lst.CarSepcificInfo.CarLocation == null ? null : lst.CarSepcificInfo.CarLocation
                                     },
                                     CarDetailInfor = lst.CarDetailInfor == null ? null : new CarDetailSepification { CarEngine = lst.CarDetailInfor.CarEngine == null ? null : new Engine {
                                         EngineTransmission = lst.CarDetailInfor.CarEngine.EngineTransmission == null ? null : lst.CarDetailInfor.CarEngine.EngineTransmission.Id != 0 ? getTransmissionList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineTransmission.Id).FirstOrDefault() : null,
                                         EngineFuel = lst.CarDetailInfor.CarEngine.EngineFuel == null ? null : getFuelList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineFuel.Id).FirstOrDefault(),
                                         EngineDrive = lst.CarDetailInfor.CarEngine.EngineDrive == null ? null : getDriveList().Where(x => x.id == lst.CarDetailInfor.CarEngine.EngineDrive.id).FirstOrDefault(),
                                         EngineClinders = lst.CarDetailInfor.CarEngine.EngineClinders == null ? null : getCylindersList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineClinders.Id).FirstOrDefault(),
                                         EngineSize = lst.CarDetailInfor.CarEngine.EngineSize == null ? null : getSizelist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineSize.Id).FirstOrDefault(),
                                         EnginePower = lst.CarDetailInfor.CarEngine.EnginePower == null ? null : getPowerlist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EnginePower.Id).FirstOrDefault(),
                                         EngineTowing = lst.CarDetailInfor.CarEngine.EngineTowing == null ? null : getTowinglist().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineTowing.Id).FirstOrDefault(),
                                         EngineInduction = lst.CarDetailInfor.CarEngine.EngineInduction == null ? null : getInductionList().Where(x => x.Id == lst.CarDetailInfor.CarEngine.EngineInduction.Id).FirstOrDefault(),
                                     },
                                         CarExtra = lst.CarDetailInfor.CarExtra == null ? null : new Extra {
                                             ExtraPplate = lst.CarDetailInfor.CarExtra.ExtraPplate == null ? null : getPplateList().Where(x => x.Id == lst.CarDetailInfor.CarExtra.ExtraPplate.Id).FirstOrDefault(),
                                             ExtraAncap = lst.CarDetailInfor.CarExtra.ExtraAncap == null ? null : getAncapList().Where(x => x.Id == lst.CarDetailInfor.CarExtra.ExtraAncap.Id).FirstOrDefault(),
                                             ExtraGreenRating = lst.CarDetailInfor.CarExtra.ExtraGreenRating == null ? null : getGreenRatingList().Where(x => x.Id == lst.CarDetailInfor.CarExtra.ExtraGreenRating.Id).FirstOrDefault()
                                         },
                                         CarStyle = lst.CarDetailInfor.CarStyle == null ? null : 
                                         new Style {
                                             StyleBody = lst.CarDetailInfor.CarStyle.StyleBody == null ? null : getBodyList().Where(x => x.Id == lst.CarDetailInfor.CarStyle.StyleBody.Id).FirstOrDefault(),
                                             StyleSeats = lst.CarDetailInfor.CarStyle.StyleSeats == null ? null : getSeatList().Where(x => x.Id == lst.CarDetailInfor.CarStyle.StyleSeats.Id).FirstOrDefault(),
                                             StyleColor = lst.CarDetailInfor.CarStyle.StyleColor == null ? null : getColorList().Where(x => x.Id == lst.CarDetailInfor.CarStyle.StyleColor.Id).FirstOrDefault(),
                                             StyleDoor = lst.CarDetailInfor.CarStyle.StyleDoor == null ? null : getDoorList().Where(x => x.Id == lst.CarDetailInfor.CarStyle.StyleDoor.Id).FirstOrDefault(),
                                         }
                                     }
                                 }).ToList();


            CarCollection carcollection = new CarCollection();

            carcollection.cars = carlist;

            return carcollection;

        }



        /// <summary>
        /// Fake car repository
        /// </summary>
        /// <param name="CarSearchResultSingle"></param>
        /// <returns></returns>
        public Car CarSearchResultSingle(Car car)
        {
            Car carresult = new Car();
            CarCollection carCollectionRepository = GetCacheCarCollection();

            carresult = carCollectionRepository.cars.Where(x => x.ID == car.ID).FirstOrDefault();

            return carresult;
        }



        /// <summary>
        /// Save car in collection object
        /// </summary>
        /// <param name="cardet"></param>
        /// <param name="carslist"></param>
        /// <returns></returns>
        public void SaveCarDetails(Car cardet)
        {

            CarCollection carcollection = GetCacheCarCollection();
            int carid = carcollection.cars.Max(x => x.ID);

            cardet.ID = carid + 1 ;

            Car cardetail = cardet;

            carcollection.cars.Add(cardetail);

            AddToCacheCarCollection(carcollection);

        }




        /// <summary>
        /// Update the Car in collection object
        /// </summary>
        /// <param name="cardet"></param>
        /// <param name="carslist"></param>
        /// <returns>CarCollection</returns>
        public void UpdateCarDetails(Car cardet)
        {

            CarCollection carcollection = GetCacheCarCollection();

            Car cardetail = carcollection.cars.Where(x => x.ID == cardet.ID).FirstOrDefault();

            carcollection.cars.Remove(cardetail);

            carcollection.cars.Add(cardet);

            AddToCacheCarCollection(carcollection);


        }






        /// <summary>
        /// Delete car from collection object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carslist"></param>
        /// <returns></returns>
        public void DeleteCarDetails(int intCarID)
        {

            CarCollection carcollection = GetCacheCarCollection();

            Car cardetail = carcollection.cars.Where(x => x.ID == intCarID).FirstOrDefault();

            carcollection.cars.Remove(cardetail);

            AddToCacheCarCollection(carcollection);



        }





        /// <summary>
        /// Store the Car collection details in Cache
        /// </summary>
        /// <param name="carcollection"></param>
        public void AddToCacheCarCollection(CarCollection carcollection)
        {

            var javascriptserializer = new JavaScriptSerializer();
            DateTimeOffset absExpiration = DateTimeOffset.UtcNow.AddHours(1);

            string carSerialize = javascriptserializer.Serialize(carcollection);
            memoryCache.Remove("carcollection");
            memoryCache.Add("carcollection", carSerialize, absExpiration);


        }




        /// <summary>
        /// Retrive Car collection details from Cache
        /// </summary>
        /// <returns></returns>
        private CarCollection GetCacheCarCollection()
        {
            var javascriptserializer = new JavaScriptSerializer();

            var strCarcol = memoryCache.Get("carcollection");
            CarCollection carcoll = javascriptserializer.Deserialize<CarCollection>(strCarcol.ToString());

            return carcoll;
        }



    
    
    }
}
