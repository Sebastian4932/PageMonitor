using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageMonitor.Aplication.Interfaces
{
    public interface IAuthenticationDataProvider
    {
        int? GetUserId();
    }
}
