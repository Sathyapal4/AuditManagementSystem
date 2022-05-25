using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Models
{
    public class SaveAuditResponse
    {
        
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManagerName { get; set; }
        public string ApplicationOwnerName { get; set; }
        public string AuditType { get; set; }
        public string AuditDate { get; set; }
        public int AuditId { get; set; }
        public string ProjectExecutionStatus { get; set; }
        public string RemedialActionDuration { get; set; }

    }
}
