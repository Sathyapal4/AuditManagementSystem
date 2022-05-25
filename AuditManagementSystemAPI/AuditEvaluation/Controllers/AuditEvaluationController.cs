using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditEvaluation.Models;
using AuditEvaluation.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditEvaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditEvaluationController : ControllerBase
    {
        private readonly log4net.ILog _log4net;
        private readonly IAuditEvaluationProvider objProvider;
        public AuditEvaluationController(IAuditEvaluationProvider _objProvider)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditEvaluationController));
            objProvider = _objProvider;
        }


        [HttpGet]
        public IActionResult AuditBenchmark()
        {
            List<Models.AuditEvaluationModel> listOfProvider = new List<Models.AuditEvaluationModel>();
            _log4net.Info(" Http GET request " + nameof(AuditEvaluationController));
            try
            {
                listOfProvider = objProvider.GetEvaluation();
                return Ok(listOfProvider);
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(AuditEvaluationController));
                return StatusCode(500);
            }
        }
    }
}
