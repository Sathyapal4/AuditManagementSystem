using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortal.Models;
using AuditManagementPortal.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        
        private readonly IAuditSeverityProvider _severityProvider;
        private readonly IAuditLoginProvider _loginProvider;
        private readonly IUserProvider _provider;
        private readonly IAuditChecklistProvider _checklistProvider;

        public HomeController(IAuditSeverityProvider severityProvider ,IAuditLoginProvider loginProvider , IUserProvider provider, IAuditChecklistProvider checklistProvider)
        {
            
            _severityProvider = severityProvider;
            _loginProvider = loginProvider;
            _provider = provider;
            _checklistProvider = checklistProvider;
        }
        
        
 

        //POST: home/login
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool value = _provider.CheckUser(user);
            ModelDTO modelDTO = new ModelDTO();
            if (value == true) 
            {
                string token = _loginProvider.GetToken();
                var t = token;

                if (t != "")
                {
                    HttpContext.Session.Clear();
                    HttpContext.Session.SetString("uid", user.Name);
                    HttpContext.Session.SetString("token", t);
                    HttpContext.Response.Cookies.Append("token", t);
                   
                    //return Ok("Login Successful");
                    modelDTO.Id = "Login";
                    modelDTO.Message = "SUCCESS";

                }
                else
                { 
                    //return NotFound(user);
                    modelDTO.Id = "Login";
                modelDTO.Message = "FAIL";
                }


            }
          
            return Ok(modelDTO);
        }




        [HttpPost]
        public IActionResult Checklist(string audittype) 
        {
            audittype = "Internal";
            if (audittype == "Internal") 
            {

                List<QuestionModel> listOfQuestions = new List<QuestionModel>();
                listOfQuestions = _checklistProvider.ProvideChecklist("Internal");
                HttpContext.Session.SetString("audittype", audittype);
                return Ok(listOfQuestions);
            }

            return Ok();
        }
        
       [HttpPost]
        public IActionResult Severity(bool q1 , bool q2, bool q3, bool q4, bool q5,
            string pName, string pmName, string oName, DateTime dateTime)
        {
            var audittype = "Internal";
            string dateTime2 = dateTime.ToString();
            //string aType = HttpContext.Session.GetString("audittype").ToString();
            string aType = audittype.ToString();
            AuditRequest auditRequest = new AuditRequest();
            AuditQuestions questions = new AuditQuestions()
            {
                Question1 = q1,
                Question2 = q2,
                Question3 = q3,
                Question4 = q4,
                Question5 = q5
            };
            auditRequest.ProjectName = pName;
            auditRequest.ProjectManagerName = pmName;
            auditRequest.ApplicationOwnerName = oName;
            auditRequest.AuditDetails = new AuditDetail() { AuditType = aType, AuditDate = dateTime2, auditQuestions = questions };
            AuditResponse auditResponse = new AuditResponse();
           
            auditResponse = _severityProvider.GetResponse(auditRequest);

            SaveAuditResponse storeAudit = new SaveAuditResponse()
            {
                ProjectName = pName,
                ProjectManagerName = pmName,
                ApplicationOwnerName = oName,
                AuditType = aType,
                AuditDate = dateTime2,
                AuditId = auditResponse.AuditId,
                ProjectExecutionStatus = auditResponse.ProjectExecutionStatus,
                RemedialActionDuration = auditResponse.RemedialActionDuration
            };
            try
            {
               
                _severityProvider.StoreResponse(storeAudit);
            }
            catch (Exception e) 
            {
                var message = e.Message;
                return Ok(message);
            }
            
            return Ok(auditResponse);
        }


    }
}
