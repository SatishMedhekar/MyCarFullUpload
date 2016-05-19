using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarsale.Client
{
   public class City
    {
        public int CityId { get; set; }
        public State State { get; set; }
        public string CityName { get; set; }
    }

    public class Location
    {
     
        public City City { get; set; }
        public State State { get; set; }
    }



    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
     }

}
