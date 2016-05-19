using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;
using MyCarsale.Domain.Repository;
using System.IO;



namespace MyCarsale.Domain.Repository
{
   public static class SetFakeCarRepository
    {

        public static void setCarFakeData()
        {
            #region Carcollection
            List<Car> CarList = new List<Car>();
            SampleCarRepository sp = new SampleCarRepository();
            CarList = new List<Car> {
            new Car
            {
                ID = 1,
                imageData = imgtoByteArray(1),
                carType = sp.geCarTypeList().Where(x => x.carTypeID == 1).FirstOrDefault(),
                CarSepcificInfo = new CarInfo
                {
                    CarMake = sp.getMakes().Where(x => x.id == 1).FirstOrDefault(),
                    CarModel = sp.getModels().Where(x => x.id == 1).FirstOrDefault(),
                    CarBadge = sp.getBadges().Where(x => x.id == 1).FirstOrDefault(),
                    CarSeries = sp.getSerieses().Where(x => x.id == 1).FirstOrDefault(),
                    CarPrice = 35000,
                    ManufactureYear = 2013,
                    intKilometer = 40000,
                    
                    KilometerRange = sp.getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            },
            new Car
            {
                ID = 2,
                imageData = imgtoByteArray(2),
                carType = sp.geCarTypeList().Where(x => x.carTypeID == 2).FirstOrDefault(),
                CarSepcificInfo = new CarInfo
                {
                    CarMake = sp.getMakes().Where(x => x.id == 2).FirstOrDefault(),
                    CarModel = sp.getModels().Where(x => x.id == 4).FirstOrDefault(),
                    CarBadge = sp.getBadges().Where(x => x.id == 4).FirstOrDefault(),
                    CarSeries = sp.getSerieses().Where(x => x.id == 4).FirstOrDefault(),
                    CarPrice = 15000,
                    ManufactureYear = 2009,
                    intKilometer = 50000,
                    KilometerRange = sp.getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            },
             new Car
            {
                ID = 3,
                imageData= imgtoByteArray(3),
                carType = sp.geCarTypeList().Where(x => x.carTypeID == 3).FirstOrDefault(),
                CarSepcificInfo = new CarInfo
                {
                    CarMake = sp.getMakes().Where(x => x.id == 3).FirstOrDefault(),
                    CarModel = sp.getModels().Where(x => x.id == 7).FirstOrDefault(),
                    CarBadge = sp.getBadges().Where(x => x.id == 7).FirstOrDefault(),
                    CarSeries = sp.getSerieses().Where(x => x.id == 7).FirstOrDefault(),
                    CarPrice = 50000,
                    ManufactureYear = 2015,
                    intKilometer = 30000,
                    KilometerRange = sp.getKMlist().Where(x => x.Id == 1).FirstOrDefault(),
                    CarLocation = new Location { city = CityRepository.getCity().Where(x => x.CityId == 1).FirstOrDefault() }
                },
                CarDetailInfor = null
            }


        };

            CarCollection carcollection = new CarCollection();
            carcollection.cars = CarList;

            sp.AddToCacheCarCollection(carcollection);

            #endregion

        }


        public static byte[] imgtoByteArray(int imageno)
        {
            using (MemoryStream mstream = new MemoryStream())
            {
                
                System.Drawing.Image img = imageno == 1 ? Properties.Resources.Image1 : imageno==2 ? Properties.Resources.Image2 : Properties.Resources.Image3;
                img.Save(mstream, img.RawFormat);
                return mstream.ToArray();
            }

        }
    }
}
