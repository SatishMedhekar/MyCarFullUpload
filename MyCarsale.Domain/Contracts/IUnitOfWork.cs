using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCarsale.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        ICarRepository Car { get; }
        IEnquiry CarEnquiry { get; }

    }
    
}
