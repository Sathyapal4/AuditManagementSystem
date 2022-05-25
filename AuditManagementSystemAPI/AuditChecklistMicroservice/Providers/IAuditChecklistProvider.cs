using AuditChecklistMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Providers
{
    public interface IAuditChecklistProvider
    {
        public List<QuestionModel> QuestionsProvider(string AuditType);
    }
}
