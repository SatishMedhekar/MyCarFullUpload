using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace MyCarsale.Domain.Contracts
{
    public interface IPrincipalProvider
    {
        IPrincipal CreatePrincipal(string username, string password);
    }
}
