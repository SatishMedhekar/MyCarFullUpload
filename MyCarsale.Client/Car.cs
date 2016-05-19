using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCarsale.Client
{


    public class CarCollection
    {
        public List<Car> cars;
    }


    public class Car
    {
        public int ID { get; set; }
        public  int imagesize { get; set; }
        public string photoname { get; set; }
        public byte[] imageData { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public CarType carType { get; set; }
        public CarInfo CarSepcificInfo { get; set; }
        public CarDetailSepification CarDetailInfor { get; set; }
        public int TotalInquiry { get; set; }

    }




    public class CustomCar
    {
        public Car car { get; set; }

        public CarSearchInfo Dropdowncollection { get; set; }

    }


    public class CarSearchInfo
    {


        public IEnumerable<CarType> carTypeList { get; set; }

        public MakeList CarMakeModelList { get; set; }

        public virtual List<Price> PriceList { get; set; }
        public IEnumerable<Year> YearList { get; set; }
        public IEnumerable<Kilometers> CarKilometer { get; set; }
        public virtual List<City> CarLocation { get; set; }
        public CarDetailSepification CarDetailInfor { get; set; }
    }


    public class CarType
    {
        public int carTypeID { get; set; }
        public string carTypeDesc { get; set; }
    }



    public class CarInfo
    {
        public Make CarMake { get; set; }
        public Model CarModel { get; set; }
        public Badge CarBadge { get; set; }
        public Series CarSeries { get; set; }
        public decimal CarPrice { get; set; }

        public int ManufactureYear { get; set; }

        public Price PriceRange { get; set; }
        public Year YearRange { get; set; }

        public int intKilometer { get; set; }
        public Kilometers KilometerRange { get; set; }
        public string strCity { get; set; }
        public Location CarLocation { get; set; }
    }

    public class CarDetailSepification
    {

        public Engine CarEngine { get; set; }
        public Style CarStyle { get; set; }
        public Extra CarExtra { get; set; }

    }




    public class Engine
    {
        public Transmission EngineTransmission { get; set; }
        public List<Transmission> EngineTransmissionList { get; set; }
        public Fuel EngineFuel { get; set; }
        public List<Fuel> EngineFuelList { get; set; }
        public Drive EngineDrive { get; set; }
        public List<Drive> EngineDriveList { get; set; }
        public Cylinders EngineClinders { get; set; }
        public List<Cylinders> EngineClindersList { get; set; }
        public Size EngineSize { get; set; }
        public List<Size> EngineSizeList { get; set; }
        public Power EnginePower { get; set; }
        public List<Power> EnginePowerList { get; set; }
        public Towing EngineTowing { get; set; }
        public List<Towing> EngineTowingList { get; set; }
        public Induction EngineInduction { get; set; }
        public List<Induction> EngineInductionList { get; set; }


    }

    public enum eTransmissionType
    {
        Any,
        Auto,
        Manual
    }


    public enum eFuel
    {
        Any,
        Diesel,
        Electric,
        LPGonly,
        Petrol,
        PetrolPremiumULP,
        PetrolUnleadedULP,
        PetrolorLPGDual

    }

    public class Style
    {
        public Body StyleBody { get; set; }
        public List<Body> StyleBodyList { get; set; }
        public Seats StyleSeats { get; set; }
        public List<Seats> StyleSeatsList { get; set; }
        public Colorcode StyleColor { get; set; }
        public List<Colorcode> StyleColorList { get; set; }
        public Door StyleDoor { get; set; }
        public List<Door> StyleDoorList { get; set; }

    }


    public class Extra
    {
        public Pplate ExtraPplate { get; set; }
        public List<Pplate> ExtraPplateList { get; set; }
        public Ancap ExtraAncap { get; set; }
        public List<Ancap> ExtraAncapList { get; set; }
        public GreenRating ExtraGreenRating { get; set; }
        public List<GreenRating> ExtraGreenRatingList { get; set; }

    }


    public class Make
    {
        public int id { get; set; }
        public string MakeType { get; set; }

    }

    public class MakeList
    {
        public List<Make> CarMakeList { get; set; }
        public List<Model> CarModelList { get; set; }
        public List<Badge> CarBadgeList { get; set; }
        public List<Series> CarSeriesList { get; set; }
    }

    public class Model
    {
        public int id { get; set; }
        public int MakeID { get; set; }
        public string ModelType { get; set; }
    }


    public class Badge
    {
        public int id { get; set; }
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string BadgeType { get; set; }
    }


    public class Series
    {
        public int id { get; set; }
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string SeriesType { get; set; }
    }


    public class Price
    {
        public Range PriceRange { get; set; }
    }


    public class Year
    {
        public Range YearRange { get; set; }
    }





    public class Drive
    {
        public int id { get; set; }
        public string DriveType { get; set; }
    }

    public class Transmission
    {
        public int Id { get; set; }
        public string TransmissionType { get; set; }
    }

    public class Fuel
    {
        public int Id { get; set; }
        public string FuelType { get; set; }
    }

    public class Device
    {
        public int Id { get; set; }
        public string DeviceType { get; set; }
    }


    public class Cylinders
    {
        public int Id { get; set; }
        public string CylinderType { get; set; }
    }

    public class Kilometers
    {
        public int Id { get; set; }
        public Range KilometerRange { get; set; }
    }


    public class Body
    {
        public int Id { get; set; }
        public string BodyType { get; set; }
    }


    public class Colorcode
    {
        public int Id { get; set; }
        public string Color { get; set; }
    }

    public class Door
    {
        public int Id { get; set; }
        public string DoorType { get; set; }
    }


    public class Pplate
    {
        public int Id { get; set; }
        public State state { get; set; }

    }


    public class Ancap
    {
        public int Id { get; set; }
        public string AncapType { get; set; }
    }


    public class GreenRating
    {
        public int Id { get; set; }
        public string GreenRatingType { get; set; }
    }




    public class Size
    {
        public int Id { get; set; }
        public Range SizeRange { get; set; }
    }


    public class Power
    {
        public int Id { get; set; }
        public Range PowerRange { get; set; }
    }


    public class Induction
    {
        public int Id { get; set; }
        public string InductionType { get; set; }
    }


    public class Towing
    {
        public int Id { get; set; }
        public Range TowingRange { get; set; }
    }


    public class Seats
    {
        public int Id { get; set; }
        public Range SeatRange { get; set; }
    }






}
