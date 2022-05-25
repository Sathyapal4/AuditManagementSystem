using AuditManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public interface IAuditChecklistProvider
    {
        public List<QuestionModel> ProvideChecklist(string audittype);
    }
}
