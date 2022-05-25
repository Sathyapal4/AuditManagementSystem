using AuditManagementPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public class AuditLoginProvider : IAuditLoginProvider
    {
        private readonly IAuditLoginRepository _auditLoginRepository;

        public AuditLoginProvider(IAuditLoginRepository auditLoginRepository)
        {
            _auditLoginRepository = auditLoginRepository;
        }
        public string GetToken()
        {
            string tokenRes = _auditLoginRepository.GetToken().Result;
            return tokenRes;
        }
    }
}
