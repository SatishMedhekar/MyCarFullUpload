using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyCarsale.WebHost.Contract
{
    public interface IPrincipalProvider
    {
        IPrincipal CreatePrincipal(string username, string password);
    }
}
