using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;


namespace MyCarsale.Domain.Repository
{
    partial class SampleCarRepository
    {


        



        public CarSearchInfo CarInfo()
        {
            CarSearchInfo cinfo = new CarSearchInfo { PriceList = getPriceRange().ToList(),
                                                      YearList = getYearlist().ToList(),
                                                      CarKilometer = getKMlist().ToList(),
                                                      CarLocation= CityRepository.getCity().ToList(),
                                                      carTypeList = geCarTypeList().ToList(),
                CarMakeModelList = new MakeList {  CarBadgeList = getBadges().ToList(),
                                                                                                                            CarMakeList = getMakes().ToList(),
                                                                                                                            CarModelList = getModels().ToList(),
                                                                                                                            CarSeriesList = getSerieses().ToList()},
                                                      CarDetailInfor = new CarDetailSepification { CarEngine = new Engine
                                                                                                                          {
                                                                                                                              EngineClindersList = getCylindersList().ToList(),
                                                                                                                              EngineDriveList = getDriveList().ToList(),
                                                                                                                              EngineFuelList = getFuelList().ToList(),
                                                                                                                              EngineInductionList = getInductionList().ToList(),
                                                                                                                              EnginePowerList = getPowerlist().ToList(),
                                                                                                                              EngineSizeList = getSizelist().ToList(),
                                                                                                                              EngineTowingList = getTowinglist().ToList(),
                                                                                                                              EngineTransmissionList = getTransmissionList().ToList(),
                                                                                                                          },
                                                                                                    CarExtra = new Extra {  ExtraAncapList = getAncapList().ToList(),
                                                                                                                            ExtraGreenRatingList = getGreenRatingList().ToList(),
                                                                                                                            ExtraPplateList = getPplateList().ToList()
                                                                                                                         },
                                                                                                    CarStyle = new Style {  StyleBodyList = getBodyList().ToList(),
                                                                                                                            StyleColorList = getColorList().ToList(),
                                                                                                                            StyleDoorList = getDoorList().ToList(),
                                                                                                                            StyleSeatsList = getSeatList().ToList()}  
                                                      }

            };
            return cinfo;
        }


        


        public IQueryable<MakeList> makelist()
        {
            List<MakeList> MakeCollection = new List<MakeList>();
            MakeList mList ;

            foreach(var a in getMakes().ToList())
            {
                mList = new MakeList
                {
                    CarMakeList = getMakes().Where(x=>x.id == a.id).ToList(),
                    CarModelList = getModels().Where(x => x.MakeID == a.id).ToList(),
                    CarBadgeList = getBadges().Where(x => x.MakeID == a.id).ToList(),
                    CarSeriesList = getSerieses().Where(x => x.MakeID == a.id).ToList()
                };

                MakeCollection.Add(mList);

            }
            
            return MakeCollection.AsQueryable();

        }




        public IQueryable<Make> getMakes()
        {
            IQueryable<Make> Make = new List<Models.Make> {new Make { id=1, MakeType="Audi" },
                                                     new Make { id=2, MakeType="Holden" },
                                                     new Make {id=3, MakeType="Ford"},
                                                     new Make {id=4, MakeType="BMW"},
                                                     new Make { id = 5, MakeType = "Honda"},
                                                     new Make {id =6, MakeType="Toyota" },
                                                     new Make { id =7, MakeType="Mercedes-Benz"}
            }.AsQueryable();
            return Make;

        }



        public IQueryable<CarType> geCarTypeList()
        {
            IQueryable<CarType> carType = new List<Models.CarType> {new CarType{ carTypeID=1, carTypeDesc="All" },
                                                     new CarType { carTypeID=2, carTypeDesc="New" },
                                                     new CarType {carTypeID=3, carTypeDesc="Used"},
                                                     new CarType {carTypeID=4, carTypeDesc="Dealer Own"},
                                                     
            }.AsQueryable();
            return carType;

        }



        public IQueryable<Model> getModels()
        {
            IQueryable<Model> Model = new List<Model> {new Model { id=1, ModelType="Q3", MakeID =1 },
                                                     new Model { id=2, ModelType="Q5", MakeID =1 },
                                                     new Model {id=3, ModelType="Q7", MakeID=1 },
                                                     new Model {id=4, ModelType="Apollo", MakeID=2 },
                                                     new Model { id = 5, ModelType = "Astra", MakeID=2},
                                                     new Model {id =6, ModelType="Barina", MakeID=2 },
                                                     new Model { id =7, ModelType="Escape", MakeID=3},
                                                     new Model { id =8, ModelType="EcoSport", MakeID=3},
                                                     new Model { id =9, ModelType="Falcon", MakeID=3},
                                                     new Model { id =10, ModelType="1 Series", MakeID=4},
                                                     new Model { id =11, ModelType="2 Series", MakeID=4},
                                                     new Model { id =12, ModelType="3 Series", MakeID=4}
            }.AsQueryable();
            return Model;

        }



        public IQueryable<Badge> getBadges()
        {
            IQueryable<Badge> Model = new List<Badge> {new Badge { id=1, BadgeType="Exclusive", MakeID =1, ModelID = 1 },
                                                     new Badge { id=2, BadgeType="High Line", MakeID =1, ModelID =2 },
                                                     new Badge {id=3, BadgeType="Highline Sport", MakeID=1, ModelID=3 },
                                                     new Badge {id=4, BadgeType="Apollo", MakeID=2 , ModelID =4},
                                                     new Badge { id = 5, BadgeType = "Astra", MakeID=2, ModelID = 5},
                                                     new Badge {id =6, BadgeType="Barina", MakeID=2, ModelID=6 },
                                                     new Badge { id =7, BadgeType="Escape", MakeID=3, ModelID =7},
                                                     new Badge { id =8, BadgeType="EcoSport", MakeID=3, ModelID =8},
                                                     new Badge { id =9, BadgeType="Falcon", MakeID=3, ModelID=9},
                                                     new Badge { id =10, BadgeType="1 Series", MakeID=4, ModelID =10},
                                                     new Badge { id =11, BadgeType="2 Series", MakeID=4, ModelID =11},
                                                     new Badge { id =12, BadgeType="3 Series", MakeID=4, ModelID = 12}
            }.AsQueryable();
            return Model;

        }



        public IQueryable<Series> getSerieses()
        {
            IQueryable<Series> Serise = new List<Series> {new Series{ id=1, SeriesType="XLS", MakeID =1, ModelID = 1 },
                                                     new Series { id=2, SeriesType ="XLT", MakeID =1, ModelID =2 },
                                                     new Series {id=3, SeriesType="Slim", MakeID=1, ModelID=3 },
                                                     new Series {id=4, SeriesType="MI", MakeID=2 , ModelID =4},
                                                     new Series { id = 5, SeriesType = "SM", MakeID=2, ModelID = 5},
                                                     new Series {id =6, SeriesType="LR", MakeID=2, ModelID=6 },
                                                     new Series { id =7, SeriesType="ELR", MakeID=3, ModelID =7},
                                                     new Series { id =8, SeriesType="UXT", MakeID=3, ModelID =8},
                                                     new Series { id =9, SeriesType="UT1", MakeID=3, ModelID=9},
                                                     new Series { id =10, SeriesType="UT2", MakeID=4, ModelID =10},
                                                     new Series { id =11, SeriesType="UT3", MakeID=4, ModelID =11},
                                                     new Series { id =12, SeriesType="UT4", MakeID=4, ModelID = 12}
            }.AsQueryable();
            return Serise;

        }


        public List<Price> getPriceRange ()
        {
            List<Price> pRange = new List<Price> { new Price { PriceRange = new Range { minvalue = 3000, maxvalue = 3000 } },
                                                         new Price { PriceRange = new Range { minvalue = 7000, maxvalue = 7000 } },
                                                         new Price { PriceRange = new Range { minvalue = 10000, maxvalue = 10000 } },
                                                         new Price { PriceRange = new Range { minvalue = 15000, maxvalue = 15000 } },
                                                         new Price { PriceRange = new Range { minvalue = 20000, maxvalue = 20000 } },
                                                         new Price { PriceRange = new Range { minvalue = 25000, maxvalue = 25000 } },
                                                         new Price { PriceRange = new Range { minvalue = 30000, maxvalue = 30000 } },
                                                         new Price { PriceRange = new Range { minvalue = 35000, maxvalue = 35000 } }
            }.ToList();


            return pRange;
        }



        public IQueryable<Year> getYearlist()
        {
            IQueryable<Year> yList = new List<Year> { new Year {YearRange = new Range {  minvalue = 2001, maxvalue = 2001} },
                                                      new Year {YearRange = new Range {  minvalue = 2002, maxvalue = 2002 } },
                                                      new Year {YearRange = new Range {  minvalue = 2003, maxvalue = 2003 } },
                                                      new Year {YearRange = new Range {  minvalue = 2004, maxvalue = 2004 } },
                                                      new Year {YearRange = new Range {  minvalue = 2005, maxvalue = 2005 } },
                                                      new Year {YearRange = new Range {  minvalue = 2006, maxvalue = 2006 } },
                                                      new Year {YearRange = new Range {  minvalue = 2007, maxvalue = 2007 } },
                                                      new Year {YearRange = new Range {  minvalue = 2008, maxvalue = 2008 } },
                                                      new Year {YearRange = new Range {  minvalue = 2009, maxvalue = 2009 } },
                                                      new Year {YearRange = new Range {  minvalue = 2010, maxvalue = 2010 } },
                                                      new Year {YearRange = new Range {  minvalue = 2011, maxvalue = 2011 } },
                                                      new Year {YearRange = new Range {  minvalue = 2012, maxvalue = 2012 }},
                                                      new Year {YearRange = new Range {  minvalue = 2013, maxvalue = 2013 }},
                                                      new Year {YearRange = new Range {  minvalue = 2014, maxvalue = 2014 }},
                                                      new Year {YearRange = new Range {  minvalue = 2015, maxvalue = 2015 } },
                                                      new Year {YearRange = new Range {  minvalue = 2016, maxvalue = 2016}},
                                                      new Year {YearRange = new Range {  minvalue = 2017, maxvalue = 2017}},
                                                      new Year {YearRange = new Range {  minvalue = 2018, maxvalue = 2018} },
                                                      new Year {YearRange = new Range {  minvalue = 2019, maxvalue = 2019}}
                                                      }.AsQueryable();
            return yList;
        }


        public IQueryable<Kilometers> getKMlist()
        {
            IQueryable<Kilometers> kList = new List<Kilometers> {  new Kilometers { Id=1, KilometerRange = new Range {  minvalue = 2001, maxvalue = 2001} },
                                                      new Kilometers {Id= 2,  KilometerRange  = new Range {  minvalue = 10000, maxvalue = 10000 } },
                                                      new Kilometers {Id=3,  KilometerRange  = new Range {  minvalue = 20000, maxvalue = 20000 } },
                                                      new Kilometers {Id=4,  KilometerRange  = new Range {  minvalue = 40000, maxvalue = 40000 } },
                                                      new Kilometers {Id=5,  KilometerRange  = new Range {  minvalue = 60000, maxvalue = 60000 } },
                                                      new Kilometers {Id=6,  KilometerRange  = new Range {  minvalue = 80000, maxvalue = 80000 } },
                                                      new Kilometers {Id=7,  KilometerRange  = new Range {  minvalue = 100000,maxvalue = 100000 } },
                                                      new Kilometers {Id=8,  KilometerRange  = new Range {  minvalue = 120000,maxvalue = 120000 } },
                                                      new Kilometers {Id=9,  KilometerRange  = new Range {  minvalue = 140000,maxvalue = 140000 } },
                                                      new Kilometers {Id=10,  KilometerRange  = new Range {  minvalue = 150000,maxvalue = 150000 } }
                                                      
                                                      }.AsQueryable();
            return kList;
        }


        /// <summary>
        /// Size
        /// </summary>
        /// <returns></returns>
        public IQueryable<Size> getSizelist()
        {
            IQueryable<Size> sList = new List<Size> { new Size { Id =1, Range = new Range {  minvalue = 1000, maxvalue = 1000} },
                                                      new Size { Id =2, Range = new Range {  minvalue = 1500, maxvalue = 1500} },
                                                      new Size { Id =3, Range = new Range {  minvalue = 2000, maxvalue = 2000} },
                                                      new Size { Id =4, Range = new Range {  minvalue = 2500, maxvalue = 2500} },
                                                      new Size { Id =5, Range = new Range {  minvalue = 3000, maxvalue = 3000} },
                                                      new Size { Id =6, Range = new Range {  minvalue = 3500, maxvalue = 3500} },
                                                      new Size { Id =7, Range = new Range {  minvalue = 4000, maxvalue = 4000} },
                                                      new Size { Id =8, Range = new Range {  minvalue = 4500, maxvalue = 4500} },
                                                      new Size { Id =9, Range = new Range {  minvalue = 5000, maxvalue = 5000} },
                                                      new Size { Id =10,Range = new Range {  minvalue = 5500, maxvalue = 5500} },

                                                      }.AsQueryable();
            return sList;
        }



        /// <summary>
        /// Towing
        /// </summary>
        /// <returns></returns>
        public IQueryable<Towing> getTowinglist()
        {
            IQueryable<Towing> sList = new List<Towing> { new Towing { Id =1, TowingRange = new Range {  minvalue = 1000, maxvalue = 1000} },
                                                      new Towing { Id =2, TowingRange = new Range {  minvalue = 1500, maxvalue = 1500} },
                                                      new Towing { Id =3, TowingRange = new Range {  minvalue = 2000, maxvalue = 2000} },
                                                      new Towing { Id =4, TowingRange = new Range {  minvalue = 2500, maxvalue = 2500} },
                                                      new Towing { Id =5, TowingRange = new Range {  minvalue = 3000, maxvalue = 3000} },
                                                      new Towing { Id =6, TowingRange = new Range {  minvalue = 3500, maxvalue = 3500} },
                                                      new Towing { Id =7, TowingRange = new Range {  minvalue = 4000, maxvalue = 4000} },
                                                      new Towing { Id =8, TowingRange = new Range {  minvalue = 4500, maxvalue = 4500} },
                                                      new Towing { Id =9, TowingRange = new Range {  minvalue = 5000, maxvalue = 5000} },
                                                      new Towing { Id =10,TowingRange = new Range {  minvalue = 5500, maxvalue = 5500} },

                                                      }.AsQueryable();
            return sList;
        }



        /// <summary>
        /// Power
        /// </summary>
        /// <returns></returns>
        public IQueryable<Power> getPowerlist()
        {
            IQueryable<Power> sList = new List<Power> { new Power { Id = 1, PowerRange = new Range { minvalue = 80, maxvalue = 80 } },
                                                      new Power { Id = 2, PowerRange = new Range { minvalue = 100, maxvalue = 100 } },
                                                      new Power { Id = 3, PowerRange = new Range { minvalue = 125, maxvalue = 125 } },
                                                      new Power { Id = 4, PowerRange = new Range { minvalue = 150, maxvalue = 150 } },
                                                      new Power { Id = 5, PowerRange = new Range { minvalue = 175, maxvalue = 175 } },
                                                      new Power { Id = 6, PowerRange = new Range { minvalue = 200, maxvalue = 200 } },
                                                      new Power { Id = 7, PowerRange = new Range { minvalue = 220, maxvalue = 220 } },
                                                      new Power { Id = 8, PowerRange = new Range { minvalue = 225, maxvalue = 220 } },
                                                      new Power { Id = 9, PowerRange = new Range { minvalue = 250, maxvalue = 250 } },
                                                      new Power { Id = 10, PowerRange= new Range { minvalue = 300, maxvalue = 300 } },

                                                      }.AsQueryable();


           
            return sList;
        }



        /// <summary>
        /// Engine Transmission
        /// </summary>
        /// <returns></returns>
        public IQueryable<Transmission> getTransmissionList()
        {
            IQueryable<Transmission> kList = new List<Transmission> { new Transmission { Id = 1, TransmissionType    = "Any"},
                                                                      new Transmission { Id = 1, TransmissionType = "Auto"},
                                                                      new Transmission { Id = 1, TransmissionType = "Manual"}
                                                                    }.AsQueryable();
            return kList;
        }



        /// <summary>
        /// Fuel
        /// </summary>
        /// <returns></returns>
        public IQueryable<Fuel> getFuelList()
        {
            IQueryable<Fuel> kList = new List<Fuel> { new Fuel{ Id = 1, FuelType   = "Any"},
                                                      new Fuel{ Id = 2, FuelType   = "Diesel"},
                                                      new Fuel{ Id = 3, FuelType   = "Electric"},
                                                      new Fuel{ Id = 4, FuelType   = "LPG Only"},
                                                      new Fuel{ Id = 5, FuelType   = "Petron"},
                                                      new Fuel{ Id = 6, FuelType   = "Petrol Premium ULP"},
                                                      new Fuel{ Id = 7, FuelType   = "Petrol Uleaded ULP"},
                                                      new Fuel{ Id = 8, FuelType   = "Petron or LPG Dual"}
                                                    }.AsQueryable();
            return kList;
        }





        /// <summary>
        /// Induction
        /// </summary>
        /// <returns></returns>
        public IQueryable<Induction> getInductionList()
        {
            IQueryable<Induction> kList = new List<Induction> { new Induction{ Id = 1, InductionType  = "Any"},
                                                      new Induction{ Id = 2, InductionType = "Aspirated"},
                                                      new Induction{ Id = 3, InductionType = "Superharged"},
                                                      new Induction{ Id = 4, InductionType = "Supercharged Intercooled"},
                                                      new Induction{ Id = 5, InductionType = "Triple Turbo Intercooled"},
                                                      new Induction{ Id = 6, InductionType = "Turbo"},
                                                      new Induction{ Id = 7, InductionType = "Turbo Intercooded"},
                                                      new Induction{ Id = 8, InductionType = "Turbo Supercharged Intercooded"}
                                                    }.AsQueryable();
            return kList;
        }






        /// <summary>
        /// Door
        /// </summary>
        /// <returns></returns>
        public IQueryable<Door> getDoorList()
        {
            IQueryable<Door> dList = new List<Door> { new Door{ Id = 1, DoorType = "Any"},
                                                      new Door{ Id = 2, DoorType   = "1"},
                                                      new Door{ Id = 3, DoorType   = "2"},
                                                      new Door{ Id = 4, DoorType   = "3"},
                                                      new Door{ Id = 5, DoorType   = "4"},
                                                      new Door{ Id = 6, DoorType   = "5"},
                                                      new Door{ Id = 7, DoorType   = "6"},
                                                      new Door{ Id = 8, DoorType   = "7"}
                                                    }.AsQueryable();
            return dList;
        }


        /// <summary>
        /// Cylinders
        /// </summary>
        /// <returns></returns>
        public IQueryable<Cylinders> getCylindersList()
        {
            IQueryable<Cylinders> dList = new List<Cylinders> { new Cylinders{ Id = 1, CylinderType = "Any"},
                                                      new Cylinders{ Id = 2, CylinderType = "1"},
                                                      new Cylinders{ Id = 3, CylinderType = "2"},
                                                      new Cylinders{ Id = 4, CylinderType = "3"},
                                                      new Cylinders{ Id = 5, CylinderType = "4"},
                                                      new Cylinders{ Id = 6, CylinderType = "5"},
                                                      new Cylinders{ Id = 7, CylinderType = "6"},
                                                      new Cylinders{ Id = 8, CylinderType = "7"}
                                                    }.AsQueryable();
            return dList;
        }


        /// <summary>
        /// Pplate
        /// </summary>
        /// <returns></returns>
        public IQueryable<Pplate> getPplateList()
        {

            
            IQueryable<Pplate> dList = new List<Pplate> { new Pplate { Id = 1, state = StateRepository.getState().Where(x => x.StateID == 1).FirstOrDefault() } ,
                                                          new Pplate { Id = 2, state = StateRepository.getState().Where(x => x.StateID == 2).FirstOrDefault() },
                                                          new Pplate { Id = 3, state = StateRepository.getState().Where(x => x.StateID == 4).FirstOrDefault() },
                                                          new Pplate { Id = 4, state = StateRepository.getState().Where(x => x.StateID == 5).FirstOrDefault() },
                                                          new Pplate { Id = 5, state = StateRepository.getState().Where(x => x.StateID == 6).FirstOrDefault() }
                                                    }.AsQueryable();
            return dList;
        }


        /// <summary>
        /// Ancap
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ancap> getAncapList()
        {


            IQueryable<Ancap> aList = new List<Ancap> { new Ancap{ Id = 1, AncapType  = "Any" },
                                                        new Ancap{ Id = 2, AncapType  = "3.5 stars or more" },
                                                        new Ancap{ Id = 3, AncapType  = "4 stars or more" },
                                                        new Ancap{ Id = 4, AncapType  = "4.5 stars or more" },
                                                        new Ancap{ Id = 5, AncapType  = "5 stars only" },
                                                        new Ancap{ Id = 5, AncapType  = "less than 3.5 stars" },
                                                    }.AsQueryable();
            return aList;
        }


        // <summary>
        /// GreenRating
        /// </summary>
        /// <returns></returns>
        public IQueryable<GreenRating> getGreenRatingList()
        {


            IQueryable<GreenRating> aList = new List<GreenRating> { new GreenRating{ Id = 1, GreenRatingType  = "Any" },
                                                        new GreenRating{ Id = 2, GreenRatingType  = "3.5 stars or more" },
                                                        new GreenRating{ Id = 3, GreenRatingType  = "4 stars or more" },
                                                        new GreenRating{ Id = 4, GreenRatingType  = "4.5 stars or more" },
                                                        new GreenRating{ Id = 5, GreenRatingType  = "5 stars only" },
                                                        new GreenRating{ Id = 5, GreenRatingType  = "less than 3.5 stars" },
                                                    }.AsQueryable();
            return aList;
        }



        // <summary>
        /// Drive
        /// </summary>
        /// <returns></returns>
        public IQueryable<Drive> getDriveList()
        {


            IQueryable<Drive> dList = new List<Drive> { new Drive { id = 1, DriveType  = "Any" },
                                                        new Drive{ id = 2, DriveType = "4*2" },
                                                        new Drive{ id = 3, DriveType = "4*4" },
                                                        new Drive{ id = 4, DriveType = "6*2" },
                                                        new Drive{ id = 5, DriveType = "6*4" },
                                                        new Drive{ id = 5, DriveType = "6*6" },
                                                        new Drive{ id = 5, DriveType = "Front Wheel Drive" },
                                                        new Drive{ id = 5, DriveType = "Rear Wheel Drive" }
                                                    }.AsQueryable();
            return dList;
        }


        /// <summary>
        /// Body List
        /// </summary>
        /// <returns></returns>
        public IQueryable<Body> getBodyList()
        {
            IQueryable<Body> bList = new List<Body> { new Body{ Id = 1, BodyType   = "Any"},
                                                      new Body{ Id = 2, BodyType   = "Cab Chassis"},
                                                      new Body{ Id = 3, BodyType   = "Coupe"},
                                                      new Body{ Id = 4, BodyType   = "Light Truck"},
                                                      new Body{ Id = 5, BodyType   = "Sedan"},
                                                      new Body{ Id = 6, BodyType   = "Ute"},
                                                      new Body{ Id = 7, BodyType   = "Wagon"},
                                                      new Body{ Id = 8, BodyType   = "Convertible"},
                                                      new Body{ Id = 9, BodyType   = "Hatch"},
                                                      new Body{ Id = 10, BodyType   = "People Mover"},
                                                      new Body{ Id = 11, BodyType   = "SUV"},
                                                      new Body{ Id = 12, BodyType   = "Van"},
                                                    }.AsQueryable();
            return bList;
        }


        /// <summary>
        /// Seats List
        /// </summary>
        /// <returns></returns>
        public IQueryable<Seats> getSeatList()
        {
            IQueryable<Seats> sList = new List<Seats> { new Seats {Id = 1, SeatRange = new Range {  minvalue = 1, maxvalue = 1} },
                                                      new Seats {Id = 2, SeatRange = new Range {  minvalue = 2, maxvalue = 2} },
                                                      new Seats {Id = 3, SeatRange = new Range {  minvalue = 3, maxvalue = 3} },
                                                      new Seats {Id = 4, SeatRange = new Range {  minvalue = 4, maxvalue = 4} },
                                                      new Seats {Id = 5, SeatRange = new Range {  minvalue = 5, maxvalue = 5} },
                                                      new Seats {Id = 6, SeatRange = new Range {  minvalue = 6, maxvalue = 6} },
                                                      new Seats {Id = 7, SeatRange = new Range {  minvalue = 7, maxvalue = 7} },
                                                      new Seats {Id = 8, SeatRange = new Range {  minvalue = 8, maxvalue = 8} },
                                                      new Seats {Id = 9, SeatRange = new Range {  minvalue = 9, maxvalue = 9} },
                                                      new Seats {Id = 10, SeatRange = new Range {  minvalue =10, maxvalue = 10} }
                                                     }.AsQueryable();
            return sList;
        }


        /// <summary>
        ///Color List
        /// </summary>
        /// <returns></returns>
        public IQueryable<Colorcode> getColorList()
        {
            IQueryable<Colorcode> cList = new List<Colorcode> { new Colorcode {Id = 1, Color = "Any" },
                                                       new Colorcode {Id = 2, Color = "Beige" },
                                                       new Colorcode {Id = 3, Color = "Black" },
                                                       new Colorcode {Id = 4, Color = "Blue" },
                                                       new Colorcode {Id = 5, Color = "Bronze" },
                                                       new Colorcode {Id = 6, Color = "Brown" },
                                                       new Colorcode {Id = 7, Color = "Burgundy" },
                                                       new Colorcode {Id = 8, Color = "GOLD" },
                                                       new Colorcode {Id = 9, Color = "Green" },
                                                       new Colorcode {Id = 10, Color = "Grey" },
                                                       new Colorcode {Id = 11, Color = "Magenta" },
                                                       new Colorcode {Id = 12, Color = "Maroon" },
                                                       new Colorcode {Id = 13, Color = "Orange" },
                                                       new Colorcode {Id = 14, Color = "Pink" },
                                                       new Colorcode {Id = 15, Color = "Purple" },
                                                       new Colorcode {Id = 16, Color = "Red" },
                                                       new Colorcode {Id = 17, Color = "Silver" },
                                                       new Colorcode {Id = 18, Color = "White" },
                                                       new Colorcode {Id = 19, Color = "Yellow" }
                                                     }.AsQueryable();
            return cList;
        }


    }


}
