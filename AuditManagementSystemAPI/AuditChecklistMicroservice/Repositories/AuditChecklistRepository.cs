using AuditChecklistMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Repositories
{
    public class AuditChecklistRepository:IAuditChecklistRepository
    {
        readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistRepository));

        private static List<QuestionModel> InternalQuestionsList = new List<QuestionModel>()
        {
            new QuestionModel
            {
                QNo=1,
                Question="Have all Change requests followed SDLC before PROD move?"
            },
            new QuestionModel
            {
                QNo=2,
                Question="Have all Change requests been approved by the application owner?"
            },
            new QuestionModel
            {
                QNo=3,
                Question="Are all artifacts like CR document, Unit test cases available?"
            },
            new QuestionModel
            {
                QNo=4,
                Question="Is the SIT and UAT sign-off available?"
            },
            new QuestionModel
            {
                QNo=5,
                Question="Is data deletion from the system done with application owner approval?"
            }
        };

     
        public List<QuestionModel> GetQuestions(string AuditType)
        {
            try
            {
                _log4net.Info("Log from " + nameof(AuditChecklistRepository));
                List<QuestionModel> listOfQuestions = new List<QuestionModel>();

                if (AuditType == "Internal")
                    listOfQuestions = InternalQuestionsList;
                
                return listOfQuestions;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception " + e.Message + nameof(AuditChecklistRepository));
                return null;

            }

        }
    }
}
