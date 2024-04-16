using PageMonitor.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageMonitor.Aplication.Interfaces
{
    public interface ICurrentAccountProvider
    {
        Task<Account> GetAuthenticatedAccount();

        Task<int?> GetAccountId();
    }
}
