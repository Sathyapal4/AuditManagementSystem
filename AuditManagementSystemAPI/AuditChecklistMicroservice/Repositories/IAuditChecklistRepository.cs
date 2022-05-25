using AuditChecklistMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Repositories
{
    public interface IAuditChecklistRepository
    {
        public List<QuestionModel> GetQuestions(string AuditType);
    }
}
