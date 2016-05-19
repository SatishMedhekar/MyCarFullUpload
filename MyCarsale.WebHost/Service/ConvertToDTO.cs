using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;
using MyCarsale.Domain.Repository;
using MyCarsale.WebHost.DTO;
using AutoMapper;
using MyCarsale.Domain.Models;


namespace MyCarsale.WebHost.Service
{
    public class ConvertToDTO
    {


        public ConvertToDTO()
        {

            Mapper.CreateMap<Price, PriceDto>();
            Mapper.CreateMap<Range, RangeDto>();
            Mapper.CreateMap<Model, ModelDto>();
            Mapper.CreateMap<Badge, BadgeDto>();
            Mapper.CreateMap<Series, SeriesDto>();
            Mapper.CreateMap<Make, MakeDto>();
            Mapper.CreateMap<Year, YearDto>();
            Mapper.CreateMap<MakeList, MakeListDto>();
            Mapper.CreateMap<CarInfoDto, CarInfo>();
            //Mapper.CreateMap<MakeListDto, MakeList>();
            Mapper.CreateMap<Kilometers, KilometersDto>();
            Mapper.CreateMap<City, CityDto>();
            Mapper.CreateMap<State, StateDto>();
            Mapper.CreateMap<CarSearchDto, CarSearchInfo>();
            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<CarInfo, CarInfoDto>();
            Mapper.CreateMap<CarDetailSepification, CarDetailSepificationDto>();
            Mapper.CreateMap<Engine, EngineDto>();
            Mapper.CreateMap<Style, StyleDto>();
            Mapper.CreateMap<Extra, ExtraDto>();
            Mapper.CreateMap<Drive, DriveDto>();
            Mapper.CreateMap<Transmission, TransmissionDto>();
            Mapper.CreateMap<Fuel, FuelDto>();
            Mapper.CreateMap<Device, DeviceDto>();
            Mapper.CreateMap<Cylinders, CylindersDto>();
            Mapper.CreateMap<Body, BodyDto>();
            Mapper.CreateMap<Colorcode, ColorcodeDto>();
            Mapper.CreateMap<Door, DoorDto>();
            Mapper.CreateMap<Pplate, PplateDto>();
            Mapper.CreateMap<Ancap, AncapDto>();
            Mapper.CreateMap<GreenRating, GreenRatingDto>();
            Mapper.CreateMap<Size, SizeDto>();
            Mapper.CreateMap<Power, PowerDto>();
            Mapper.CreateMap<Induction, InductionDto>();
            Mapper.CreateMap<Towing, TowingDto>();
            Mapper.CreateMap<Seats, SeatsDto>();
            
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<PersonalInfo, PersonalInfoDto>();
            Mapper.CreateMap<ContactInfo, ContactInfoDto>();
            Mapper.CreateMap<Address, AddressDto>();
            Mapper.CreateMap<Enquiry, EnquiryDto>();
            Mapper.CreateMap<CarType, CarTypeDto>();
            Mapper.CreateMap<CarCollection, CarCollectionDto>();




            Mapper.CreateMap<CarSearchInfo, CarSearchDto>()
                   //.ForMember(x => x.PriceList, m => m.MapFrom
                   //                (
                   //                    q => Mapper.Map<IList<Price>, IList<PriceDto>>(q.PriceList)
                   //                )
                   //          )
                   //.ForMember(x => x.CarMakeList, m => m.MapFrom
                   //                  (
                   //                      q => Mapper.Map<IList<MakeList>, IList<MakeListDto>>(q.CarMakeList.ToList())
                   //                  )
                   //    )

                   //.ForMember(x => x.CarLocation, m => m.MapFrom
                   //                (
                   //                    q => Mapper.Map<IList<City>, IList<CityDto>>(q.CarLocation)
                   //                )
                   //    )
                   //.ForMember(dest => dest.CarLocation, m=>m.MapFrom(q=>q.CarLocation ) )
                   //.ForMember(dest => dest.YearList, m => m.MapFrom(q => q.YearList))
                   //.ForMember(dest => dest.CarKilometer, m => m.MapFrom(q => q.CarKilometer))
                   //.ForMember(dest => dest.CarLocation, opt => opt.Ignore())
                   //.ForMember(dest => dest.YearList, opt => opt.Ignore())
                   //.ForMember(dest => dest.CarKilometer, opt => opt.Ignore())

                   ;


            Mapper.CreateMap<PriceDto, Price>();
            Mapper.CreateMap<RangeDto, Range>();
            Mapper.CreateMap<ModelDto, Model>();
            Mapper.CreateMap<BadgeDto, Badge>();
            Mapper.CreateMap<SeriesDto, Series>();
            Mapper.CreateMap<MakeDto, Make>();
            Mapper.CreateMap<YearDto, Year>();
            Mapper.CreateMap<MakeListDto, MakeList>();
            Mapper.CreateMap<CarInfoDto, CarInfo>();
            //Mapper.CreateMap<MakeListDto, MakeList>();
            Mapper.CreateMap<KilometersDto, Kilometers>();
            Mapper.CreateMap<CityDto, City>();
            Mapper.CreateMap<StateDto, State>();
            Mapper.CreateMap<CarSearchDto, CarSearchInfo>();
            Mapper.CreateMap<LocationDto, Location>();
            Mapper.CreateMap<CarDto, Car>();
            Mapper.CreateMap<CarInfoDto, CarInfo>();
            Mapper.CreateMap<CarDetailSepificationDto, CarDetailSepification>();
            Mapper.CreateMap<EngineDto, Engine>();
            Mapper.CreateMap<StyleDto, Style>();
            Mapper.CreateMap<ExtraDto, Extra>();
            Mapper.CreateMap<DriveDto, Drive>();
            Mapper.CreateMap<TransmissionDto, Transmission>();
            Mapper.CreateMap<FuelDto, Fuel>();
            Mapper.CreateMap<DeviceDto, Device>();
            Mapper.CreateMap<CylindersDto, Cylinders>();
            Mapper.CreateMap<BodyDto, Body>();
            Mapper.CreateMap<ColorcodeDto, Colorcode>();
            Mapper.CreateMap<DoorDto, Door>();
            Mapper.CreateMap<PplateDto, Pplate>();
            Mapper.CreateMap<AncapDto, Ancap>();
            Mapper.CreateMap<GreenRatingDto, GreenRating>();
            Mapper.CreateMap<SizeDto, Size>();
            Mapper.CreateMap<PowerDto, Power>();
            Mapper.CreateMap<InductionDto, Induction>();
            Mapper.CreateMap<TowingDto, Towing>();
            Mapper.CreateMap<SeatsDto, Seats>();
            Mapper.CreateMap<ContactInfoDto, ContactInfo>();
            Mapper.CreateMap<EnquiryDto, Enquiry>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<PersonalInfoDto, PersonalInfo>();
            Mapper.CreateMap<ContactInfoDto, ContactInfo>();
            Mapper.CreateMap<AddressDto, Address>();
            Mapper.CreateMap<CarTypeDto, CarType>();
            Mapper.CreateMap<CarCollectionDto, CarCollection>();

        }


        public CarSearchDto GetCarServiceDto(CarSearchInfo carsearchinfo)
        {

            //var response = carsearchinfo.To<CarSearchDto>();
            var response = Mapper.Map<CarSearchDto>(carsearchinfo);

            return response;

        }



        public CarInfo GetCarServiceDto(CarInfoDto carsearchinfo)
        {

            //var response = carsearchinfo.To<CarSearchDto>();
            var response = Mapper.Map<CarInfo>(carsearchinfo);

            return response;

        }




        public Customer GetEnquiryeDto(EnquiryDto enquiryRequestDto)
        {
            Enquiry cust = new Enquiry();
            //var response = carsearchinfo.To<CarSearchDto>();

            var response1 = Mapper.Map<EnquiryDto>(cust);
            var response = new Customer();
            return response;

        }
    }
}