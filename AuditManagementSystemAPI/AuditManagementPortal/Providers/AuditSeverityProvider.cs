using AuditManagementPortal.Models;
using AuditManagementPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public class AuditSeverityProvider : IAuditSeverityProvider
    {
        private readonly IAuditSeverityRepository _auditSeverityRepository;

        public AuditSeverityProvider(IAuditSeverityRepository auditSeverityRepository)
        {
            _auditSeverityRepository = auditSeverityRepository;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest)
        {
            AuditResponse auditResponse = new AuditResponse();
            auditResponse = _auditSeverityRepository.GetResponse(auditRequest);
            return auditResponse;
        }
        public void StoreResponse(SaveAuditResponse auditResponse)
        {
            _auditSeverityRepository.StoreResponse(auditResponse);
        }


    }
}
