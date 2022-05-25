using AuditSeverityMicroservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Repositories
{
    public class AuditSeverityRepository:IAuditSeverityRepository
    {


        //Uri baseAddress;
        readonly HttpClient client;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityRepository));

        public AuditSeverityRepository()//IConfiguration configuration
        {
            
            client = new HttpClient();
        }

        public List<AuditEvaluationModel> Response()
        {
            _log4net.Info(" Response Method of SeverityRepo is called ");
            try
            {

                List<AuditEvaluationModel> listFromAuditBenchmark = new List<AuditEvaluationModel>();
                HttpResponseMessage response = client.GetAsync("https://localhost:44395/api"+"/AuditEvaluation").Result; //client.BaseAddress
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    listFromAuditBenchmark = JsonConvert.DeserializeObject<List<AuditEvaluationModel>>(data);
                }
                return listFromAuditBenchmark;

            }
            catch (Exception ey)
            {
                _log4net.Error(ey.Message);
                return null;
            }

        }











        public static List<AuditResponse> ActionToTakeAndStatus = new List<AuditResponse>()
        {
            new AuditResponse
            {
                RemedialActionDuration="No Action Needed",
                ProjectExecutionStatus="GREEN"
            },
            new AuditResponse
            {
                RemedialActionDuration="Action to be taken in 2 weeks",
                ProjectExecutionStatus="RED"
            },
            new AuditResponse
            {
                RemedialActionDuration = "Action to be taken in 1 week",
                 ProjectExecutionStatus="RED"
            }
        };
    }
}
