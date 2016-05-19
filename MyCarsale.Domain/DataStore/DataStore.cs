using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Repository;
using MyCarsale.Domain.Models;
using MyCarsale.Domain.Contracts;

namespace MyCarsale.Domain.DataStore
{
    public class DataStore:IUnitOfWork
    {

        private ICarRepository cars;
        private IEnquiry enquiry;


        public void Commit()
        {

        }
               

        public ICarRepository Car
        {
            get
            {
                if (cars == null)
                    cars = new SampleCarRepository();

                return cars;
            }
        }

        public IEnquiry CarEnquiry
        {
            get
            {
                if (enquiry == null)
                    enquiry = new SampleEnquiry();
                return enquiry;
            }
        }
    }


    
}
