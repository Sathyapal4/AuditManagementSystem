using AuditChecklistMicroservice.Models;
using AuditChecklistMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Providers
{
    public class AuditChecklistProvider:IAuditChecklistProvider
    {
        private readonly IAuditChecklistRepository checklistRepoObj;
        readonly log4net.ILog _log4net;
        public AuditChecklistProvider(IAuditChecklistRepository _checklistRepoObj)
        {
            checklistRepoObj = _checklistRepoObj;
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistProvider));
        }
        List<QuestionModel> listOfQuestions = new List<QuestionModel>();

        public List<QuestionModel> QuestionsProvider(string AuditType)
        {

            _log4net.Info(" Http GET request called" + nameof(AuditChecklistProvider));
            listOfQuestions = checklistRepoObj.GetQuestions(AuditType);
            return listOfQuestions;
        }
    }
}
