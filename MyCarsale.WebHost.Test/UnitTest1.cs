using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCarsale.WebHost.Controllers;
using MyCarsale.WebHost.DTO;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.DataStore;

namespace MyCarsale.WebHost.Test
{
    [TestClass]
    public class UnitTest1
    {

        #region Member
        private CarInfoDto _carinfo;
        private CarSearchDto _carsearchdto;
        private EnquiryDto _carenquiry;
        private CarCollectionDto _carcol;
        private List<CarDto> _carlist;
        private CarDto _car;
        private IUnitOfWork _Unit;
        

        #endregion
        [TestInitialize]
            public void Initialise_Me()
        {

            _Unit = new DataStore();

            #region Enquiry
            _carenquiry = new EnquiryDto
                    { 
                        CustomerDetail = new CustomerDto
                        {
                            CustomerName = new PersonalInfoDto
                            {
                                FName = "Tom",
                                LName = "Smith",
                                Email = "tom@yahoo.com",
                                PhoneInfo = new ContactInfoDto { Mobile = 0421457859, Phone = 0269587748 }
                            },
                            
                        },
                       
                        Comment = " Hi I am interested in this model, could you please quote me right price"
                    };


            #endregion


            #region CarInfo
                _carinfo = new CarInfoDto { PriceRange = new PriceDto { PriceRange = new RangeDto { minvalue = 40000, maxvalue = 50000 } } };
            #endregion


            #region Carcollection

            _carlist = new List<CarDto> {
            new CarDto
            {

                ID = 1,
                CarSepcificInfo = new CarInfoDto
                {
                    CarMake = new MakeDto { id=1, MakeType="Audi" },
                    CarModel = new ModelDto { id=1, ModelType="Q3", MakeID =1 },
                    CarBadge = new BadgeDto { id=1, BadgeType="Exclusive", MakeID =1, ModelID = 1 },
                    CarSeries = new SeriesDto { id=1, SeriesType="XLS", MakeID =1, ModelID = 1 },
                    CarPrice = 35000,
                    ManufactureYear = 2013,
                    intKilometer = 40000,
                    KilometerRange = new KilometersDto { Id=1, KilometerRange = new RangeDto {  minvalue = 2001, maxvalue = 2001} },
                    CarLocation = new LocationDto { state = new StateDto { StateID = 1 }, city = new CityDto { CityId = 1, Name = "Richmond" , State = new StateDto { StateID=1, Name="NSW" } }
                }},
                CarDetailInfor = new CarDetailSepificationDto { CarEngine = new EngineDto { EngineSize = new SizeDto { Id =2},
                                                               EngineClinders = new CylindersDto { Id = 3} ,
                                                               EngineDrive = new DriveDto { id = 3},
                                                               EngineFuel = new FuelDto { Id = 3} ,
                                                               EngineInduction = new InductionDto{ Id = 3},
                                                               EnginePower = new PowerDto { Id = 3},
                                                               EngineTowing  = new TowingDto { Id =3},
                                                               EngineTransmission = new TransmissionDto { Id = 3} },
                                                               CarExtra = new ExtraDto { ExtraAncap = new AncapDto{ Id = 3},
                                                               ExtraGreenRating = new GreenRatingDto { Id = 3},
                                                               ExtraPplate = new PplateDto { Id = 1, state = new StateDto { StateID = 1 }  }
                                                              }
                                                                }

            } ,

             new CarDto
            {

                ID = 2,
                CarSepcificInfo = new CarInfoDto
                {
                    CarMake = new MakeDto { id=2, MakeType="Holden" },
                    CarModel = new ModelDto {id=4, ModelType="Apollo", MakeID=2 },
                    CarBadge = new BadgeDto {id=4, BadgeType="Apollo", MakeID=2 , ModelID =4},
                    CarSeries = new SeriesDto {id=4, SeriesType="MI", MakeID=2 , ModelID =4},
                    CarPrice = 50000,
                    ManufactureYear = 2015,
                    intKilometer = 1000,
                    KilometerRange = new KilometersDto { Id=2},
                    CarLocation = new LocationDto { state = new StateDto { StateID = 1 }, city = new CityDto { CityId = 1, State = new StateDto { StateID=1} }
                }},
                CarDetailInfor = new CarDetailSepificationDto { CarEngine = new EngineDto { EngineSize = new SizeDto { Id =2},
                                                               EngineClinders = new CylindersDto { Id = 2} ,
                                                               EngineDrive = new DriveDto { id = 2},
                                                               EngineFuel = new FuelDto { Id = 2} ,
                                                               EngineInduction = new InductionDto{ Id = 2},
                                                               EnginePower = new PowerDto { Id = 2},
                                                               EngineTowing  = new TowingDto { Id =2},
                                                               EngineTransmission = new TransmissionDto { Id = 2} },
                                                               CarExtra = new ExtraDto { ExtraAncap = new AncapDto{ Id = 1},
                                                               ExtraGreenRating = new GreenRatingDto { Id = 1},
                                                               ExtraPplate = new PplateDto { Id = 1, state = new StateDto { StateID = 1 }  }
                                                              }
                                                                }


            } };

            
            #endregion


            #region Car
            _car = new CarDto
            {

                ID = 2,
                CarSepcificInfo = new CarInfoDto
                {
                    CarMake = new MakeDto { id = 3, MakeType = "Ford" },
                    CarModel = new ModelDto { id = 7, ModelType = "Escape", MakeID = 3 },
                    CarBadge = new BadgeDto { id = 8, BadgeType = "EcoSport", MakeID = 3, ModelID = 8 },
                    CarSeries = new SeriesDto { id = 7, SeriesType = "ELR", MakeID = 3, ModelID = 7 },
                    CarPrice = 70000,
                    ManufactureYear = 2016,
                    intKilometer = 100,
                    KilometerRange = new KilometersDto { Id = 2 },
                    CarLocation = new LocationDto
                    {
                        state = new StateDto { StateID = 1 },
                        city = new CityDto { CityId = 1, State = new StateDto { StateID = 1 } }
                    }
                },
                CarDetailInfor = new CarDetailSepificationDto
                {
                    CarEngine = new EngineDto
                    {
                        EngineSize = new SizeDto { Id = 2 },
                        EngineClinders = new CylindersDto { Id = 2 },
                        EngineDrive = new DriveDto { id = 2 },
                        EngineFuel = new FuelDto { Id = 2 },
                        EngineInduction = new InductionDto { Id = 2 },
                        EnginePower = new PowerDto { Id = 2 },
                        EngineTowing = new TowingDto { Id = 2 },
                        EngineTransmission = new TransmissionDto { Id = 2 }
                    },
                    CarExtra = new ExtraDto
                    {
                        ExtraAncap = new AncapDto { Id = 1 },
                        ExtraGreenRating = new GreenRatingDto { Id = 1 },
                        ExtraPplate = new PplateDto { Id = 1, state = new StateDto { StateID = 1 } }
                    }
                }


            };

            _carcol = new CarCollectionDto();
            _carcol.cars = _carlist;

            #endregion


            #region SetFakeCarRepository

                MyCarsale.Domain.Repository.SetFakeCarRepository.setCarFakeData();

            #endregion



        }





        [TestMethod]
        public void Get_CarSearchCriteria()
        {
           

            HomeController home = new HomeController(_Unit);
            var cs =  home.Get();

            Assert.Equals(_carsearchdto, cs);
        }




        [TestMethod]
        public void Get_CarSearch()
        {
            
            
            var carsearchdto = new CarCollectionDto();

            HomeController home = new HomeController(_Unit);
            var cs = home.CarSearchResult(_carinfo);

            Assert.Equals(carsearchdto, cs);
        }


        [TestMethod]
        public void Post_SubmitEnquiry()
        {
            

            var carsearchdto = new CarSearchDto();

            EnquiryController home = new EnquiryController(_Unit);
            var cs = home.Post(_carenquiry);

            Assert.Equals(carsearchdto, cs);
        }



        [TestMethod]
        public void Post_AddCar()
        {
            
            var carcol= new CarCollectionDto();

            carcol.cars = _carlist;

            CarController carctl = new CarController(_Unit);

            var cs = carctl.Post(_car);

            Assert.Equals(carcol, cs);
        }

    }

}
