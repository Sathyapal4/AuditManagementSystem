using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Models
{
    public class AuditEvaluationModel
    {
        public string AuditType { get; set; }
        public int EvalResponsesNum { get; set; }
    }
}
