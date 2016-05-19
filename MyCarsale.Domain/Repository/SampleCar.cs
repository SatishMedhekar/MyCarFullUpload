using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Contracts;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Repository
{
    public class SampleCar 
    {
        public CarSearchInfo CarSearch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<Car> CarSearchResult(CarInfo carrequest)
        {
            throw new NotImplementedException();
        }


        public void DeleteCarDetails(Car Cardetail)
        {
            throw new NotImplementedException();
        }


        public CarCollection SaveCarDetails(Car cardet, CarCollection carslist)
        {
            throw new NotImplementedException();

        }


        public IQueryable<Car> SearchCar(CarInfo carrequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateCarDetails(Car Cardetail)
        {
            throw new NotImplementedException();
        }
    }
}
