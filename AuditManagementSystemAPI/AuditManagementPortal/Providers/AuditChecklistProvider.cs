using AuditManagementPortal.Models;
using AuditManagementPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public class AuditChecklistProvider : IAuditChecklistProvider
    {
        private readonly IAuditChecklistRepository _auditChecklistRepository;

        public AuditChecklistProvider(IAuditChecklistRepository auditChecklistRepository)
        {
            _auditChecklistRepository = auditChecklistRepository;
        }
        public List<QuestionModel> ProvideChecklist(string audittype)
        {
            List<QuestionModel> questionModelList = new List<QuestionModel>();
            questionModelList = _auditChecklistRepository.ProvideChecklist(audittype);
            return questionModelList;
        }
    }
}
