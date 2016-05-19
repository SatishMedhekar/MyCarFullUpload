using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCarsale.Client;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace MyCarSale.App.Service
{
    public class service
    {

        public Car InitialiseCar()
        {
            Car car = new Car();


            car.CarDetailInfor = new CarDetailSepification
            {
                CarEngine = new Engine
                {
                    EngineClinders = new Cylinders { Id = 0, CylinderType = "" },
                    EngineDrive = new Drive { id = 0, DriveType = "" },
                    EngineFuel = new Fuel { Id = 0, FuelType = "" },
                    EngineInduction = new Induction { Id = 0, InductionType = "" },
                    EnginePower = new Power { Id = 0, PowerRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EngineSize = new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EngineTowing = new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } }
                },
                CarExtra = new Extra
                {
                    ExtraAncap = new Ancap { Id = 0, AncapType = "" },
                    ExtraGreenRating = new GreenRating { Id = 0, GreenRatingType = "" },
                    ExtraPplate = new Pplate { Id = 0, state = new State { StateID = 0, StateName = "" } }
                },
                CarStyle = new Style
                {
                    StyleBody = new Body { Id = 0, BodyType = "" },
                    StyleColor = new Colorcode { Id = 0, Color = "" },
                    StyleDoor = new Door { Id = 0, DoorType = "" },
                    StyleSeats = new Seats { Id = 0, SeatRange = new Range { maxvalue = 0, minvalue = 0 } }


                }
            };


            car.CarSepcificInfo = new CarInfo
            {
                CarBadge = new Badge { id = 0, BadgeType = "" },
                CarMake = new Make { id = 0, MakeType = "" },
                CarModel = new Model { id = 0, MakeID = 0, ModelType = "" },
                CarSeries = new Series { id = 0, MakeID = 0, ModelID = 0, SeriesType = "" },
                CarLocation = new Location { City = new City { CityId = 0, CityName = "", State = new State { StateID = 0, StateName = "" } } }
            };

            return car;
        }




        public Car InitialiseCar(Car c)
        {
            Car car = new Car();
            CarDetailSepification carinfo = new CarDetailSepification();
            Engine eng = new Engine();
            car = c;

            car.carType = new CarType { carTypeID = 0, carTypeDesc = "" };
            car.ID = c.ID;
            car.imageData = c.imageData ?? imgtoByteArray();
            car.imagesize = 0;
            //car.Photo = c.Photo ?? null;
            car.photoname = c.photoname ?? "";


            carinfo = c.CarDetailInfor == null ? InitialiseCarDetailInfor() : new CarDetailSepification();

            car.CarDetailInfor = carinfo;

            eng = c.CarDetailInfor.CarEngine == null ? InitialiseEngine() : new Engine
            {
                EngineClinders = c.CarDetailInfor.CarEngine.EngineClinders ?? new Cylinders { Id = 0, CylinderType = "" },
                EngineDrive = c.CarDetailInfor.CarEngine.EngineDrive ?? new Drive { id = 0, DriveType = "" },
                EngineFuel = c.CarDetailInfor.CarEngine.EngineFuel ?? new Fuel { Id = 0, FuelType = "" },
                EngineInduction = c.CarDetailInfor.CarEngine.EngineInduction ?? new Induction { Id = 0, InductionType = "" },
                EnginePower = c.CarDetailInfor.CarEngine.EnginePower ?? new Power { Id = 0, PowerRange = c.CarDetailInfor.CarEngine.EnginePower.PowerRange ?? new Range { minvalue = 0, maxvalue = 0 } },
                EngineSize = c.CarDetailInfor.CarEngine.EngineSize ?? new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } },
                EngineTowing = c.CarDetailInfor.CarEngine.EngineTowing ?? new Towing { Id = 0, TowingRange = c.CarDetailInfor.CarEngine.EngineTowing.TowingRange ?? new Range { minvalue = 0, maxvalue = 0 } },
                EngineClindersList = c.CarDetailInfor.CarEngine.EngineClindersList != null ? c.CarDetailInfor.CarEngine.EngineClindersList : new List<Cylinders> { new Cylinders { Id = 0, CylinderType = "" } },
                EngineDriveList = c.CarDetailInfor.CarEngine.EngineDriveList != null ? c.CarDetailInfor.CarEngine.EngineDriveList : new List<Drive> { new Drive { id = 0, DriveType = "" } },
                EngineFuelList = c.CarDetailInfor.CarEngine.EngineFuelList != null ? c.CarDetailInfor.CarEngine.EngineFuelList : new List<Fuel> { new Fuel { Id = 0, FuelType = "" } },
                EngineInductionList = c.CarDetailInfor.CarEngine.EngineInductionList != null ? c.CarDetailInfor.CarEngine.EngineInductionList : new List<Induction> { new Induction { Id = 0, InductionType = "" } },
                EnginePowerList = c.CarDetailInfor.CarEngine.EnginePowerList != null ? c.CarDetailInfor.CarEngine.EnginePowerList : new List<Power> { new Power { Id = 0, PowerRange = new Range { maxvalue = 0, minvalue = 0 } } },
                EngineSizeList = c.CarDetailInfor.CarEngine.EngineSizeList != null ? c.CarDetailInfor.CarEngine.EngineSizeList : new List<Size> { new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } } },
                EngineTowingList = c.CarDetailInfor.CarEngine.EngineTowingList != null ? c.CarDetailInfor.CarEngine.EngineTowingList : new List<Towing> { new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } } },
                EngineTransmissionList = c.CarDetailInfor.CarEngine.EngineTransmissionList != null ? c.CarDetailInfor.CarEngine.EngineTransmissionList : new List<Transmission> { new Transmission { Id = 0, TransmissionType = "" } },
                EngineTransmission = c.CarDetailInfor.CarEngine.EngineTransmission ?? new Transmission { Id = 0, TransmissionType = "" }
            };

            car.CarDetailInfor.CarEngine = eng;
            



            Extra extra = new Extra();



            extra = c.CarDetailInfor.CarExtra == null ? InitialiseExtra() : new Extra
            {
                ExtraAncap = c.CarDetailInfor.CarExtra.ExtraAncap != null ? c.CarDetailInfor.CarExtra.ExtraAncap : new Ancap { Id = 0, AncapType = "" },
                ExtraGreenRating = c.CarDetailInfor.CarExtra.ExtraGreenRating != null ? c.CarDetailInfor.CarExtra.ExtraGreenRating : new GreenRating { Id = 0, GreenRatingType = "" },
                ExtraPplate = c.CarDetailInfor.CarExtra.ExtraPplate != null ? c.CarDetailInfor.CarExtra.ExtraPplate : new Pplate { Id = 0, state = c.CarDetailInfor.CarExtra.ExtraPplate.state ?? new State { StateID = 0, StateName = "" } },
                ExtraAncapList = c.CarDetailInfor.CarExtra.ExtraAncapList != null ? c.CarDetailInfor.CarExtra.ExtraAncapList : new List<Ancap> { new Ancap { Id = 0, AncapType = "" } },
                ExtraGreenRatingList = c.CarDetailInfor.CarExtra.ExtraGreenRatingList != null ? c.CarDetailInfor.CarExtra.ExtraGreenRatingList : new List<GreenRating> { new GreenRating { Id = 0, GreenRatingType = "" } }
            };

            car.CarDetailInfor.CarExtra = extra;

            Style style = new Style();
            style = c.CarDetailInfor.CarStyle == null ? InitialiseStyle() : new Style
            {
                StyleBody = c.CarDetailInfor.CarStyle.StyleBody ?? new Body { Id = 0, BodyType = "" },
                StyleColor = c.CarDetailInfor.CarStyle.StyleColor ?? new Colorcode { Id = 0, Color = "" },
                StyleDoor = c.CarDetailInfor.CarStyle.StyleDoor ?? new Door { Id = 0, DoorType = "" },
                StyleSeats = c.CarDetailInfor.CarStyle.StyleSeats ?? new Seats { Id = 0, SeatRange = c.CarDetailInfor.CarStyle.StyleSeats.SeatRange ?? new Range { maxvalue = 0, minvalue = 0 } },
                StyleBodyList = c.CarDetailInfor.CarStyle.StyleBodyList != null ? c.CarDetailInfor.CarStyle.StyleBodyList : new List<Body> { new Body { Id = 0, BodyType = "" } },
                StyleColorList = c.CarDetailInfor.CarStyle.StyleColorList != null ? c.CarDetailInfor.CarStyle.StyleColorList : new List<Colorcode> { new Colorcode { Id = 0, Color = "" } },
                StyleDoorList = c.CarDetailInfor.CarStyle.StyleDoorList != null ? c.CarDetailInfor.CarStyle.StyleDoorList : new List<Door> { new Door { Id = 0, DoorType = "" } },
                StyleSeatsList = c.CarDetailInfor.CarStyle.StyleSeatsList != null ? c.CarDetailInfor.CarStyle.StyleSeatsList : new List<Seats> { new Seats { Id = 0, SeatRange = new Range { minvalue = 0, maxvalue = 0 } } }
            };

            car.CarDetailInfor.CarStyle = style;

            car.CarSepcificInfo = c.CarSepcificInfo == null ? InitialiseCarInfor() : new CarInfo
            {
                CarBadge = c.CarSepcificInfo.CarBadge ?? new Badge { id = 0, BadgeType = "" },
                CarMake = c.CarSepcificInfo.CarMake ?? new Make { id = 0, MakeType = "" },
                CarModel = c.CarSepcificInfo.CarModel ?? new Model { id = 0, MakeID = 0, ModelType = "" },
                CarSeries = c.CarSepcificInfo.CarSeries ?? new Series { id = 0, MakeID = 0, ModelID = 0, SeriesType = "" },
                CarLocation = new Location { City = new City { CityId = 0, CityName = "", State = new State { StateID = 0, StateName = "" } } },
                CarPrice = c.CarSepcificInfo.CarPrice,
                intKilometer = c.CarSepcificInfo.intKilometer,
                KilometerRange = c.CarSepcificInfo.KilometerRange ?? new Kilometers { Id = 0, KilometerRange = new Range { minvalue = 0, maxvalue = 0 } },
                ManufactureYear = c.CarSepcificInfo.ManufactureYear,
                PriceRange = c.CarSepcificInfo.PriceRange ?? new Price { PriceRange = new Range { minvalue = 0, maxvalue = 0 } },
                strCity = c.CarSepcificInfo.strCity ?? "",
                YearRange = c.CarSepcificInfo.YearRange ?? new Year { YearRange = new Range { minvalue = 0, maxvalue = 0 } }




            };

            return car;

        }




        public Engine InitialiseEngine()
        {
            Engine eng = new Engine
            {
                EngineClinders = new Cylinders { Id = 0, CylinderType = "" },
                EngineDrive = new Drive { id = 0, DriveType = "" },
                EngineFuel = new Fuel { Id = 0, FuelType = "" },
                EngineInduction = new Induction { Id = 0, InductionType = "" },
                EnginePower = new Power { Id = 0, PowerRange = new Range { minvalue = 0, maxvalue = 0 } },
                EngineSize = new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } },
                EngineTowing = new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } },
                EngineClindersList = new List<Cylinders> { new Cylinders { Id = 0, CylinderType = "" } },
                EngineDriveList = new List<Drive> { new Drive { id = 0, DriveType = "" } },
                EngineFuelList = new List<Fuel> { new Fuel { Id = 0, FuelType = "" } },
                EngineInductionList = new List<Induction> { new Induction { Id = 0, InductionType = "" } },
                EnginePowerList = new List<Power> { new Power { Id = 0, PowerRange = new Range { maxvalue = 0, minvalue = 0 } } },
                EngineSizeList = new List<Size> { new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } } },
                EngineTowingList = new List<Towing> { new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } } },
                EngineTransmissionList = new List<Transmission> { new Transmission { Id = 0, TransmissionType = "" } },
                EngineTransmission = new Transmission { Id = 0, TransmissionType = "" }
            };
            return eng;
            }



        public Style InitialiseStyle()
        {
            Style st = new Style
            {
                StyleBody = new Body { Id = 0, BodyType = "" },
                StyleColor = new Colorcode { Id = 0, Color = "" },
                StyleDoor = new Door { Id = 0, DoorType = "" },
                StyleSeats = new Seats { Id = 0, SeatRange = new Range { maxvalue = 0, minvalue = 0 } },
                StyleBodyList = new List<Body> { new Body { Id = 0, BodyType = "" } },
                StyleColorList = new List<Colorcode> { new Colorcode { Id = 0, Color = "" } },
                StyleDoorList = new List<Door> { new Door { Id = 0, DoorType = "" } },
                StyleSeatsList = new List<Seats> { new Seats { Id = 0, SeatRange = new Range { minvalue = 0, maxvalue = 0 } } }
            };

            return st;
        }

        public Extra InitialiseExtra()
        {
            Extra ex = new Extra
            {
                ExtraAncap = new Ancap { Id = 0, AncapType = "" },
                ExtraGreenRating = new GreenRating { Id = 0, GreenRatingType = "" },
                ExtraPplate = new Pplate { Id = 0, state = new State { StateID = 0, StateName = "" } },
                ExtraAncapList = new List<Ancap> { new Ancap { Id = 0, AncapType = "" } },
                ExtraGreenRatingList = new List<GreenRating> { new GreenRating { Id = 0, GreenRatingType = "" } }
            };
            return ex;

        }




        public CarCollection InitialiseCarList(CarCollection carlst)
        {

            CarCollection carresponse = new CarCollection();
            carresponse.cars = new List<Car>();



            foreach (Car c in carlst.cars)
            {
                Car car = new Car();
                car = InitialiseCar(c);

                carresponse.cars.Add(car);

            }

            return carresponse;
        }


        public CarDetailSepification InitialiseCarDetailInfor()
        {
            Car car = new Car();


            CarDetailSepification CarDetailInfor = new CarDetailSepification
            {
                CarEngine = new Engine
                {
                    EngineClinders = new Cylinders { Id = 0, CylinderType = "" },
                    EngineClindersList = new List<Cylinders> { new Cylinders { Id = 0, CylinderType = "" } },
                    EngineDrive = new Drive { id = 0, DriveType = "" },
                    EngineDriveList = new List<Drive> { new Drive { id = 0, DriveType = "" } },
                    EngineFuel = new Fuel { Id = 0, FuelType = "" },
                    EngineFuelList = new List<Fuel> { new Fuel { Id = 0, FuelType = "" } },
                    EngineInduction = new Induction { Id = 0, InductionType = "" },
                    EngineInductionList = new List<Induction> { new Induction { Id = 0, InductionType = "" } },
                    EnginePower = new Power { Id = 0, PowerRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EnginePowerList = new List<Power> { new Power { Id = 0, PowerRange = new Range { maxvalue = 0, minvalue = 0 } } },
                    EngineSize = new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EngineSizeList = new List<Size> { new Size { Id = 0, SizeRange = new Range { minvalue = 0, maxvalue = 0 } } },
                    EngineTowing = new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } },
                    EngineTowingList = new List<Towing> { new Towing { Id = 0, TowingRange = new Range { minvalue = 0, maxvalue = 0 } } },
                    EngineTransmission = new Transmission { Id = 0, TransmissionType = "" },
                    EngineTransmissionList = new List<Transmission> { new Transmission { Id = 0, TransmissionType = "" } },

                },
                CarExtra = new Extra
                {
                    ExtraAncap = new Ancap { Id = 0, AncapType = "" },
                    ExtraGreenRating = new GreenRating { Id = 0, GreenRatingType = "" },
                    ExtraPplate = new Pplate { Id = 0, state = new State { StateID = 0, StateName = "" } },
                    ExtraAncapList = new List<Ancap> { new Ancap { Id = 0, AncapType = "" } },
                    ExtraPplateList = new List<Pplate> { new Pplate { Id = 0, state = new State { StateID = 0, StateName = "" } } },
                    ExtraGreenRatingList = new List<GreenRating> { new GreenRating { Id = 0, GreenRatingType = "" } }
                },
                CarStyle = new Style
                {
                    StyleBody = new Body { Id = 0, BodyType = "" },
                    StyleColor = new Colorcode { Id = 0, Color = "" },
                    StyleDoor = new Door { Id = 0, DoorType = "" },
                    StyleSeats = new Seats { Id = 0, SeatRange = new Range { maxvalue = 0, minvalue = 0 } },
                    StyleBodyList = new List<Body> { new Body { Id = 0, BodyType = "" } },
                    StyleColorList = new List<Colorcode> { new Colorcode { Id = 0, Color = "" } },
                    StyleDoorList = new List<Door> { new Door { Id = 0, DoorType = "" } },
                    StyleSeatsList = new List<Seats> { new Seats { Id = 0, SeatRange = new Range { maxvalue = 0, minvalue = 0 } } }


                }
            };


            car.CarSepcificInfo = new CarInfo
            {
                CarBadge = new Badge { id = 0, BadgeType = "" },
                CarMake = new Make { id = 0, MakeType = "" },
                CarModel = new Model { id = 0, MakeID = 0, ModelType = "" },
                CarSeries = new Series { id = 0, MakeID = 0, ModelID = 0, SeriesType = "" },
                CarLocation = new Location { City = new City { CityId = 0, CityName = "", State = new State { StateID = 0, StateName = "" } } },
                CarPrice = 0,
                intKilometer = 0,
                KilometerRange = new Kilometers { Id = 0, KilometerRange = new Range { minvalue = 0, maxvalue = 0 } },
                ManufactureYear = 0,
                PriceRange = new Price { PriceRange = new Range { maxvalue = 0, minvalue = 0 } },
                strCity = "",
                YearRange = new Year { YearRange = new Range { minvalue = 0, maxvalue = 0 } }
            };

            return CarDetailInfor;
        }




        public CarInfo InitialiseCarInfor()
        {
            Car car = new Car();


            CarInfo CarSepcificInfo = new CarInfo
            {
                CarBadge = new Badge { id = 0, BadgeType = "" },
                CarMake = new Make { id = 0, MakeType = "" },
                CarModel = new Model { id = 0, MakeID = 0, ModelType = "" },
                CarSeries = new Series { id = 0, MakeID = 0, ModelID = 0, SeriesType = "" },
                CarLocation = new Location { City = new City { CityId = 0, CityName = "", State = new State { StateID = 0, StateName = "" } } }
            };

            return CarSepcificInfo;
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




        public void ProcessOrder(Enquiry enq)
        {
            string MailToAddress = enq.CustomerDetail.CustomerName.Email;
            string MailFromAddress = "sat_medh@yahoo.com";
            bool UseSsl = true;
            string Username = "sat_medh@yahoo.com";
            string Password = "";
            string ServerName = "smtp.mail.yahoo.com";
            int ServerPort = 587;
            bool WriteAsFile = false;
            string FileLocation = @"c:\sports_store_emails";

            using (var smtpClient = new SmtpClient())
            {



                smtpClient.EnableSsl = UseSsl;
                smtpClient.Host = ServerName;
                smtpClient.Port = ServerPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials
                    = new NetworkCredential(Username, Password);

                //if (WriteAsFile)
                //{
                //    smtpClient.DeliveryMethod
                //        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                //    smtpClient.PickupDirectoryLocation = FileLocation;
                //    smtpClient.EnableSsl = false;
                //}

                //StringBuilder body = new StringBuilder()
                //    .AppendLine("Thank you for showing interest in our car")
                //    .AppendLine("---")
                //    .AppendLine("Some one will get back to you")
                //    .AppendLine("Sale Admin");

                //MailMessage mailMessage = new MailMessage(
                //                       MailFromAddress,   // From
                //                       MailToAddress,     // To
                //                      "New order submitted!",          // Subject
                //                       body.ToString());                // Body

                //if (WriteAsFile)
                //{
                //    mailMessage.BodyEncoding = Encoding.ASCII;
                //}

                //smtpClient.Send(mailMessage);
                try
                {

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(MailFromAddress);
                        mail.To.Add(MailToAddress);
                        mail.Subject = "Hello " + enq.CustomerDetail.CustomerName.FName + ' ' + enq.CustomerDetail.CustomerName.FName;

                        StringBuilder body = new StringBuilder()
                            .AppendLine("Thank you for showing interest in our car")
                            .AppendLine("---")
                            .AppendLine("Some one will get back to you")
                            .AppendLine("Sale Admin");


                        mail.Body = body.ToString();
                        mail.IsBodyHtml = true;
                        // Can set to false, if you are sending pure text.



                        using (SmtpClient smtp = new SmtpClient(ServerName, ServerPort))
                        {
                            smtp.Credentials = new NetworkCredential(MailFromAddress, Password);
                            smtp.EnableSsl = UseSsl;
                            smtp.Send(mail);
                        }
                    }
                }
                catch { }

            }





        }
    }
}