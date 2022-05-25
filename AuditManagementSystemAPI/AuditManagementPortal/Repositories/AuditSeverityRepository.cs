using AuditManagementPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditManagementPortal.Repositories
{
    public class AuditSeverityRepository : IAuditSeverityRepository
    {
        private readonly AuditDbContext _auditDbContext;

        public AuditSeverityRepository(AuditDbContext auditDbContext)
        {
            _auditDbContext = auditDbContext;
        }
        public AuditResponse GetResponse(AuditRequest auditRequest)
        {
            AuditResponse auditResponse = new AuditResponse();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(auditRequest), Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync("https://localhost:44354/api/AuditSeverity", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    auditResponse = JsonConvert.DeserializeObject<AuditResponse>(result);
                }

            }
            return auditResponse;
        }

        public void StoreResponse(SaveAuditResponse auditResponse) 
        {
            _auditDbContext.savedAuditResponses.Add(auditResponse);
            _auditDbContext.SaveChanges();

        }

    }
}
