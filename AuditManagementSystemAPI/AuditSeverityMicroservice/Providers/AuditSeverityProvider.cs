using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Providers
{
    public class AuditSeverityProvider:IAuditSeverityProvider
    {
        private readonly IAuditSeverityRepository _auditSeverityRepository;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityProvider));
        public AuditSeverityProvider(IAuditSeverityRepository auditSeverityRepository)
        {
            _auditSeverityRepository = auditSeverityRepository;
        }
        public AuditResponse SeverityResponse(AuditRequest Req)
        {
            _log4net.Info(" SeverityResponse Method of SeverityProvider is called ");
            try
            {
                List<AuditEvaluationModel> listfromRepository = _auditSeverityRepository.Response();

                int count = 0;
                int acceptableNo = 0;

                if (Req.AuditDetails.auditQuestions.Question1 == false)
                    count++;
                if (Req.AuditDetails.auditQuestions.Question2 == false)
                    count++;
                if (Req.AuditDetails.auditQuestions.Question3 == false)
                    count++;
                if (Req.AuditDetails.auditQuestions.Question4 == false)
                    count++;
                if (Req.AuditDetails.auditQuestions.Question5 == false)
                    count++;

                if (Req.AuditDetails.AuditType == listfromRepository[0].AuditType)
                    acceptableNo = listfromRepository[0].EvalResponsesNum;
                else if (Req.AuditDetails.AuditType == listfromRepository[1].AuditType)
                    acceptableNo = listfromRepository[1].EvalResponsesNum;


                Random randomNumber = new Random();


                AuditResponse auditResponse = new AuditResponse();
                if (Req.AuditDetails.AuditType == "Internal" && count <= acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExecutionStatus = AuditSeverityRepository.ActionToTakeAndStatus[0].ProjectExecutionStatus;
                    auditResponse.RemedialActionDuration = AuditSeverityRepository.ActionToTakeAndStatus[0].RemedialActionDuration;
                }
                else if (Req.AuditDetails.AuditType == "Internal" && count > acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExecutionStatus = AuditSeverityRepository.ActionToTakeAndStatus[1].ProjectExecutionStatus;
                    auditResponse.RemedialActionDuration = AuditSeverityRepository.ActionToTakeAndStatus[1].RemedialActionDuration;
                }
               

                return auditResponse;
            }
            catch (Exception ex)
            {
                _log4net.Error(ex.Message);
                return null;
            }


        }
    }
}
