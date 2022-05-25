using AuditManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public interface IUserProvider
    {
        public bool CheckUser(User user);
    }
}
