using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarsale.Domain.Models;

namespace MyCarsale.Domain.Contracts
{
   public interface ICarRepository
    {
        CarCollection CarSearchResult(CarInfo carrequest);

        CarSearchInfo CarSearch { get; }

        void SaveCarDetails(Car cardet);

        void UpdateCarDetails(Car cardet);

        void DeleteCarDetails(int intCarID);

        Car CarSearchResultSingle(Car car);





    }
}
