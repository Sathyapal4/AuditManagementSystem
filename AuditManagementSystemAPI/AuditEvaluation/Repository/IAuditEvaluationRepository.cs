using AuditEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditEvaluation.Repository
{
    public interface IAuditEvaluationRepository
    {
        public List<Models.AuditEvaluationModel> GetNolist();

    }
}
