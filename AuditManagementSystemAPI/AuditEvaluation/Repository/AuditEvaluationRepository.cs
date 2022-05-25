using AuditEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditEvaluation.Repository
{
    public class AuditEvaluationRepository : IAuditEvaluationRepository
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditEvaluationRepository));
        private static List<Models.AuditEvaluationModel> AuditBenchmarkList = new List<Models.AuditEvaluationModel>()
        {
            new Models.AuditEvaluationModel
            {
                AuditType="Internal",
                EvalResponsesNum=3
            }
        };
        public List<Models.AuditEvaluationModel> GetNolist()
        {
            _log4net.Info(" Http GET request " + nameof(AuditEvaluationRepository));
            List<Models.AuditEvaluationModel> listOfCriteria = new List<Models.AuditEvaluationModel>();
            try
            {
                listOfCriteria = AuditBenchmarkList;
                return listOfCriteria;
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(AuditEvaluationRepository));
                return null;
            }

        }
    }
}
