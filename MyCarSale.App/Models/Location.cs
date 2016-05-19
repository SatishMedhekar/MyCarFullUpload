using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarSale.App.Models
{
   public class City
    {
        public int CityId { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
    }

    public class Location
    {
     
        public City city { get; set; }
    }



    public class State
    {
        public int StateID { get; set; }
        public string Name { get; set; }
     }

}
