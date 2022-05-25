using AuditSeverityMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Providers
{
    public interface IAuditSeverityProvider
    {
        public AuditResponse SeverityResponse(AuditRequest Req);
    }
}
