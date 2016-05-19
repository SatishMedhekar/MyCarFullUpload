using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarSale.App.Models
{


    public class Enquiry
    {
        public int ID { get; set; }
        public Customer CustomerDetail { get; set; }
        public List<Car> CarEnquiryDetail { get; set; }
        public string Comment { get; set; }
    }

    public class Customer
    {
        public int ID { get; set; }
        public PersonalInfo CustomerName { get; set; }
        public Address CustomerAddress { get; set; }
    }

    public class PersonalInfo
    {
       
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public ContactInfo PhoneInfo { get; set; }
        

    }

    public class ContactInfo
    {
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string WorkPhone { get; set; }
        public string AfterHourContact { get; set; }
    }


    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Location AreaLocation{ get; set; }
        public string Postcode { get; set; }
    }
}
