using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Models
{
    public class AuditDetail
    {
        public string AuditType { get; set; }
     
        public string AuditDate { get; set; }
        public AuditQuestions auditQuestions { get; set; }

    }
}
