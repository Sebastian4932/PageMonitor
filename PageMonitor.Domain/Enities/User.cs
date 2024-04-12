using PageMonitor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageMonitor.Domain.Enities
{
    public class User : DomainEntity
    {
        public required string Email { get; set; }

        public required string HashedPassword { get; set; }

        public DateTime ReqisterDate { get; set; }

        public ICollection<AccountUser> AccountUsers { get; set; } = new List<AccountUser>();
    }
}
