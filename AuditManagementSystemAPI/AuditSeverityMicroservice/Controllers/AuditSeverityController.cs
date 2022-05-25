using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private readonly IAuditSeverityProvider _severityProvider;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditSeverityController));
        public AuditSeverityController(IAuditSeverityProvider severityProvider)
        {
            _severityProvider = severityProvider;
        }

        [HttpGet]
        public IActionResult ProjectExecutionStatus()
        {
            _log4net.Info(" Http GET Request From: " + nameof(AuditSeverityController));
            return Ok("WORKING SUCCESSFULLY!!!!");
        }



        [HttpPost]
        public IActionResult ProjectExecutionStatus([FromBody] AuditRequest req)
        {
            _log4net.Info(" Http POST Request From: " + nameof(AuditSeverityController));

            if (req == null)
                return BadRequest();

            if (req.AuditDetails.AuditType != "Internal")
                return BadRequest("Wrong Audit Type");

            try
            {
                AuditResponse response = _severityProvider.SeverityResponse(req);
                return Ok(response);
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                return StatusCode(500);
            }

        }
    }
}
