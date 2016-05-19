using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Repository
{
    public static class CityRepository
    {
        private static IQueryable<City> city = new List<City> {
            new City { CityId = 1, Name = "Richmond" , State = new State { StateID=1, Name="NSW" } },
            new City {CityId=2, Name="Blue Mountains",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 3, Name= "Newcastle",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 4, Name = "Richmond",State = new State { StateID=1, Name="NSW" } },
            new City {CityId=5, Name="Gosford",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 6, Name= "Wollongong",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 7, Name = "Maitland",State = new State { StateID=1, Name="NSW" } },
            new City {CityId=8, Name="Albury",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 9, Name= "Wagga Wagga ",State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 10, Name = "Tamworth",State = new State { StateID=1, Name="NSW" }},
            new City {CityId=11, Name="Blue Mountains", State = new State { StateID=1, Name="NSW" } },
            new City { CityId = 12, Name= "" },

            new City { CityId = 13, Name = "" },
            new City {CityId=14, Name="" },
            new City { CityId = 15, Name= "" },

            new City { CityId = 16, Name = "" },
            new City {CityId=17, Name="" },
            new City { CityId = 18, Name= "" },

            new City { CityId = 19, Name = "" },
            new City {CityId=20, Name="Blue " },
            new City { CityId = 21, Name= "" },



        }.AsQueryable();


        public static IQueryable<City> getCity()
        {
            return city;
        }


    }

    public static class StateRepository
    {
        private static IQueryable<State> state = new List<State> {
            new State{ StateID= 1, Name = "Any" },
            new State{ StateID= 2, Name = "NSW" },
            new State{StateID=3, Name="ACT" },
            new State { StateID = 4, Name= "VIC" },

        }.AsQueryable();


        public static IQueryable<State> getState()
        {
            return StateRepository.state;
        }
    }
}
