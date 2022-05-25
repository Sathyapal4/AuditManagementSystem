using AuditChecklistMicroservice.Models;
using AuditChecklistMicroservice.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : Controller
    {
        private readonly IAuditChecklistProvider checklistProviderobj;
        readonly log4net.ILog _log4net;

        public AuditChecklistController(IAuditChecklistProvider _checklistProviderobj)
        {
            checklistProviderobj = _checklistProviderobj;
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        }

        [HttpGet]
        public IActionResult AuditCheckListQuestions([FromBody] string AuditType)
        {


            _log4net.Info("AuditChecklistController Http GET request called" + nameof(AuditChecklistController));
            if (string.IsNullOrEmpty(AuditType))
                return BadRequest("No Input");
            if ((AuditType != "Internal"))
                return Ok("Wrong Input");

            try
            {
                List<QuestionModel> list = checklistProviderobj.QuestionsProvider(AuditType);
                return Ok(list);
            }
            catch (Exception e)
            {
                _log4net.Error("Exception " + e.Message + nameof(AuditChecklistController));
                return StatusCode(500);
            }
        }
    }
}
