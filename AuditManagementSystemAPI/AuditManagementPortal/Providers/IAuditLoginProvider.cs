using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public interface IAuditLoginProvider
    {
        public string GetToken();
    }
}
