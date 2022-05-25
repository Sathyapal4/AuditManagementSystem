using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditManagementPortal.Repositories
{
    public class AuditLoginRepository : IAuditLoginRepository
    {
        public async Task<string> GetToken()
        {
            string getToken = "";
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://localhost:44380/api/AuthToken"))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    getToken = token;

                }

            }

            return getToken;
        }
    }
}
