using AuditSeverityMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Repositories
{
    public interface IAuditSeverityRepository
    {
        public List<AuditEvaluationModel> Response();
    }
}
