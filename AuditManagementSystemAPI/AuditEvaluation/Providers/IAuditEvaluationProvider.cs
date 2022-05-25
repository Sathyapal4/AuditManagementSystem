using AuditEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditEvaluation.Providers
{
        public interface IAuditEvaluationProvider
        {
            public List<Models.AuditEvaluationModel> GetEvaluation();
        }
    
}
