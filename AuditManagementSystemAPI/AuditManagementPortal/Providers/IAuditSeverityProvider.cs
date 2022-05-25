using AuditManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public interface IAuditSeverityProvider
    {
        public AuditResponse GetResponse(AuditRequest auditRequest);
        public void StoreResponse(SaveAuditResponse auditResponse);
    }
}
