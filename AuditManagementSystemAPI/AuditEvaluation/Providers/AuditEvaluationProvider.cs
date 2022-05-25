using AuditEvaluation.Models;
using AuditEvaluation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditEvaluation.Providers
{
    public class AuditEvaluationProvider : IAuditEvaluationProvider
    {
        private readonly IAuditEvaluationRepository objBenchmarkRepo;
        private readonly log4net.ILog _log4net;
        public AuditEvaluationProvider(IAuditEvaluationRepository _objBenchmarkRepo)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditEvaluationProvider));
            objBenchmarkRepo = _objBenchmarkRepo;
        }

        public List<Models.AuditEvaluationModel> GetEvaluation()
        {
            _log4net.Info(" Http GET request " + nameof(AuditEvaluationProvider));

            List<Models.AuditEvaluationModel> listOfRepository = new List<Models.AuditEvaluationModel>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(AuditEvaluationProvider));
                return null;
            }

        }

    }
}
