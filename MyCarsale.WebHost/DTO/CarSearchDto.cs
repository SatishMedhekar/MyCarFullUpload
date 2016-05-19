using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCarsale.WebHost.DTO
{



    #region CarDto

    public class CarCollectionDto
    {
        [JsonProperty("cars")]
        public List<CarDto> cars;
    }

    public class EnquiryCollectionDto
    {
        [JsonProperty("Enquiries")]
        public List<EnquiryDto> Enquiries { get; set; }
    }


    public class CarDto
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("imagesize")]
        public int imagesize { get; set; }

        [JsonProperty("photoname")]
        public string photoname { get; set; }

        [JsonProperty("imageData")]
        public byte[] imageData { get; set; }

        [JsonProperty("carType")]
        public CarTypeDto carType { get; set; }


        [JsonProperty("CarSepcificInfo")]
        public CarInfoDto CarSepcificInfo { get; set; }

        [JsonProperty("CarDetailInfor")]
        public CarDetailSepificationDto CarDetailInfor { get; set; }
    }



    #region CarDetailSpecification
    public class CarDetailSepificationDto
    {
        [JsonProperty("CarEngine")]
        public EngineDto CarEngine { get; set; }

        [JsonProperty("CarStyle")]
        public StyleDto CarStyle { get; set; }

        [JsonProperty("CarExtra")]
        public ExtraDto CarExtra { get; set; }

    }



    public class CarTypeDto
    {
        [JsonProperty("carTypeID")]
        public int carTypeID { get; set; }

        [JsonProperty("carTypeDesc")]
        public string carTypeDesc { get; set; }
    }



    #region Style
    public class StyleDto
    {
        [JsonProperty("StyleBody")]
        public BodyDto StyleBody { get; set; }

        [JsonProperty("StyleBodyList")]
        public List<BodyDto> StyleBodyList { get; set; }

        [JsonProperty("StyleSeats")]
        public SeatsDto StyleSeats { get; set; }

        [JsonProperty("StyleSeatsList")]
        public List<SeatsDto> StyleSeatsList { get; set; }


        [JsonProperty("StyleColor")]
        public ColorcodeDto StyleColor { get; set; }


        [JsonProperty("StyleColorList")]
        public List<ColorcodeDto> StyleColorList { get; set; }


        [JsonProperty("StyleDoor")]
        public DoorDto StyleDoor { get; set; }

        [JsonProperty("StyleDoorList")]
        public List<DoorDto> StyleDoorList { get; set; }

    }



    public class BodyDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; set; }
    }

    public class SeatsDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("SeatRange")]
        public RangeDto SeatRange { get; set; }
    }


    public class ColorcodeDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }
    }

    public class DoorDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("DoorTye")]
        public string DoorType { get; set; }
    }

    #endregion

    #region Extra
    public class ExtraDto
    {
        [JsonProperty("ExtraPplate")]
        public PplateDto ExtraPplate { get; set; }

        [JsonProperty("ExtraPplateList")]
        public List<PplateDto> ExtraPplateList { get; set; }

        [JsonProperty("ExtraAncap")]
        public AncapDto ExtraAncap { get; set; }


        [JsonProperty("ExtraAncapList")]
        public List<AncapDto> ExtraAncapList { get; set; }


        [JsonProperty("ExtraGreenRating")]
        public GreenRatingDto ExtraGreenRating { get; set; }

        [JsonProperty("ExtraGreenRatingList")]
        public List<GreenRatingDto> ExtraGreenRatingList { get; set; }
    }



    public class PplateDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("State")]
        public StateDto state { get; set; }

    }


    public class AncapDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("AncapType")]
        public string AncapType { get; set; }
    }


    public class GreenRatingDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("GreenRatingType")]
        public string GreenRatingType { get; set; }
    }

    #endregion

    #endregion




    #region Engine






    public class EngineDto
    {
        [JsonProperty("EngineTransmission")]
        public TransmissionDto EngineTransmission { get; set; }

        [JsonProperty("EngineTransmissionList")]
        public List<TransmissionDto> EngineTransmissionList { get; set; }

        [JsonProperty("EngineFuel")]
        public FuelDto EngineFuel { get; set; }

        [JsonProperty("EngineFuelList")]
        public List<FuelDto> EngineFuelList { get; set; }

        [JsonProperty("EngineDrive")]
        public DriveDto EngineDrive { get; set; }

        [JsonProperty("EngineDriveList")]
        public List<DriveDto> EngineDriveList { get; set; }

        [JsonProperty("EngineCylinder")]
        public CylindersDto EngineClinders { get; set; }

        [JsonProperty("EngineClindersList")]
        public List<CylindersDto> EngineClindersList { get; set; }

        [JsonProperty("EngineSize")]
        public SizeDto EngineSize { get; set; }

        [JsonProperty("EngineSizeList")]
        public List<SizeDto> EngineSizeList { get; set; }

        [JsonProperty("EnginePower")]
        public PowerDto EnginePower { get; set; }

        [JsonProperty("EnginePowerList")]
        public List<PowerDto> EnginePowerList { get; set; }

        [JsonProperty("EngineTowing")]
        public TowingDto EngineTowing { get; set; }

        [JsonProperty("EngineTowingList")]
        public List<TowingDto> EngineTowingList { get; set; }

        [JsonProperty("EngineInduction")]
        public InductionDto EngineInduction { get; set; }

        [JsonProperty("EngineInductionList")]
        public List<InductionDto> EngineInductionList { get; set; }
    }



    public class TransmissionDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("TransmissionType")]
        public string TransmissionType { get; set; }
    }


    public class FuelDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("FuelType")]
        public string FuelType { get; set; }
    }


    public class DriveDto
    {
        [JsonProperty("ID")]
        public int id { get; set; }

        [JsonProperty("DriveType")]
        public string DriveType { get; set; }
    }


    public class CylindersDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("CylinderType")]
        public string CylinderType { get; set; }
    }


    public class SizeDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("SizeRange")]
        public RangeDto Range { get; set; }
    }


    public class PowerDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("PowerRange")]
        public RangeDto PowerRange { get; set; }
    }

    public class InductionDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("InductionType")]
        public string InductionType { get; set; }
    }


    public class TowingDto
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("TowingRange")]
        public RangeDto TowingRange { get; set; }
    }

    #endregion


    #endregion


    #region CarSearch and CarInfo

    #region CarSearchDto

    public class CarSearchDto
    {
        [JsonProperty("carTypeList")]
        public List<CarTypeDto> carTypeList { get; set; }

        [JsonProperty("CarMakeModelList")]
        public MakeListDto CarMakeModelList { get; set; }

        [JsonProperty("PriceList")]
        public virtual List<PriceDto> PriceList { get; set; }

        [JsonProperty("YearList")]
        public List<YearDto> YearList { get; set; }

        [JsonProperty("CarKilometer")]
        public List<KilometersDto> CarKilometer { get; set; }

        [JsonProperty("CarLocation")]
        public List<CityDto> CarLocation { get; set; }

        [JsonProperty("CarDetailInfor")]
        public CarDetailSepificationDto CarDetailInfor { get; set; }
    }


    #region MakeList

    public class MakeListDto
    {
        [JsonProperty("CarMakeList")]
        public ICollection<MakeDto> CarMakeList { get; set; }

        [JsonProperty("CarModelList")]
        public ICollection<ModelDto> CarModelList { get; set; }

        [JsonProperty("CarBadgeList")]
        public ICollection<BadgeDto> CarBadgeList { get; set; }

        [JsonProperty("CarSeriesList")]
        public ICollection<SeriesDto> CarSeriesList { get; set; }
    }

    #endregion
    #endregion


    #region CarInfoDto
    public class CarInfoDto
    {

        [JsonProperty("CarMake")]
        public MakeDto CarMake { get; set; }

        [JsonProperty("CarModel")]
        public ModelDto CarModel { get; set; }

        [JsonProperty("CarBadge")]
        public BadgeDto CarBadge { get; set; }

        [JsonProperty("CarSeries")]
        public SeriesDto CarSeries { get; set; }

        [JsonProperty("CarPrice")]
        public decimal CarPrice { get; set; }

        [JsonProperty("ManufactureYear")]
        public int  ManufactureYear { get; set; }


        [JsonProperty("PriceRange")]
        public  PriceDto PriceRange { get; set; }

        [JsonProperty("YearRange")]
        public YearDto YearRange { get; set; }

        [JsonProperty("intKilometer")]
        public int intKilometer { get; set; }

        [JsonProperty("KilometerRange")]
        public KilometersDto KilometerRange { get; set; }

        [JsonProperty("strCity")]
        public string strCity { get; set; }

        [JsonProperty("CarLocation")]
        public LocationDto CarLocation { get; set; }
    }

    #endregion



    public class MakeDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("MakeType")]
        public string MakeType { get; set; }
    }


    public class ModelDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("MakeID")]
        public int MakeID { get; set; }

        [JsonProperty("ModelType")]
        public string ModelType { get; set; }
    }


    public class BadgeDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("ModelID")]
        public int ModelID { get; set; }

        [JsonProperty("MakeID")]
        public int MakeID { get; set; }

        [JsonProperty("BadgeType")]
        public string BadgeType { get; set; }
    }



    public class SeriesDto
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("ModelID")]
        public int ModelID { get; set; }

        [JsonProperty("MakeID")]
        public int MakeID { get; set; }

        [JsonProperty("SeriesType")]
        public string SeriesType { get; set; }
    }


    public class PriceDto
    {
        [JsonProperty("PriceRange")]
        public RangeDto PriceRange { get; set; }
    }

    public class YearDto
    {
        [JsonProperty("YearRange")]
        public RangeDto YearRange { get; set; }
    }



    public class KilometersDto
    {
        [JsonProperty("KilometerID")]
        public int Id { get; set; }

        [JsonProperty("KilometerRange")]
        public RangeDto KilometerRange { get; set; }
    }

    public class RangeDto
    {
        [JsonProperty("minvalue")]
        public int minvalue { get; set; }

        [JsonProperty("maxvalue")]
        public int maxvalue { get; set; }
    }



    public class CityDto
    {
        [JsonProperty("CityID")]
        public int CityId { get; set; }

        [JsonProperty("State")]
        public StateDto State { get; set; }

        [JsonProperty("CityName")]
        public string Name { get; set; }
    }

    public class LocationDto
    {
        [JsonProperty("State")]
        public StateDto state { get; set; }

        [JsonProperty("City")]
        public CityDto city { get; set; }
    }



    public class StateDto
    {
        [JsonProperty("StateID")]
        public int StateID { get; set; }

        [JsonProperty("StateName")]
        public string Name { get; set; }
    }
    #endregion



    public class DeviceDto
        {[JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("DeviceType")]
        public string DeviceType { get; set; }
    }


    public class EnquiryDto
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        
        [JsonProperty("CustomerDetail")]
        public CustomerDto CustomerDetail { get; set; }

        
        [JsonProperty("CarId")]
        public int CarId { get; set; }

        [JsonProperty("Comment")]
        public string Comment { get; set; }
    }


    public class CustomerDto
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("CustomerName")]
        public PersonalInfoDto CustomerName { get; set; }

       
    }


    public class PersonalInfoDto
    {
        [JsonProperty("FName")]
        public string FName { get; set; }

        [JsonProperty("LName")]
        public string LName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("PhoneInfo")]
        public ContactInfoDto PhoneInfo { get; set; }
    }


    public class ContactInfoDto
    {
        [JsonProperty("Mobile")]
        public int  Mobile { get; set; }

        [JsonProperty("Phone")]
        public int Phone { get; set; }

        [JsonProperty("WorkPhone")]
        public int WorkPhone { get; set; }

        [JsonProperty("AfterHourContact")]
        public int AfterHourContact { get; set; }
    }



    public class AddressDto
    {
        [JsonProperty("Address1")]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        public string Address2 { get; set; }

        [JsonProperty("AreaLocation")]
        public LocationDto AreaLocation { get; set; }

        [JsonProperty("Postcode")]
        public string Postcode { get; set; }
   }

}