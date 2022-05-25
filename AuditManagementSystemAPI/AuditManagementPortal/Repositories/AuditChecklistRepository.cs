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
    public class AuditChecklistRepository : IAuditChecklistRepository
    {
        public List<QuestionModel> ProvideChecklist(string audittype)
        {

            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(audittype);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44320/api/AuditChecklist"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            List<QuestionModel> listOfQuestions = new List<QuestionModel>();
            var response = client.SendAsync(request).ConfigureAwait(false);

            var responseInfo = response.GetAwaiter().GetResult();
            if (responseInfo.IsSuccessStatusCode)
            {
                var questions = responseInfo.Content.ReadAsStringAsync().Result;
                listOfQuestions = JsonConvert.DeserializeObject<List<QuestionModel>>(questions);
            }
            return listOfQuestions;
            
        }
    }
}
