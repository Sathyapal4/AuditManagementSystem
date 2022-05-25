using AuditManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Repositories
{
    public interface IAuditSeverityRepository
    {
        public AuditResponse GetResponse(AuditRequest auditRequest);
        public void StoreResponse(SaveAuditResponse auditResponse);
    }
}
