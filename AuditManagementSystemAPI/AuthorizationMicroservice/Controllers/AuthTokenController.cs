using AuthorizationMicroservice.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTokenController : ControllerBase
    {
        private readonly IAuthorizationProvider _authorizationProvider;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthTokenController));
        public AuthTokenController(IAuthorizationProvider authorizationProvider)
        {
            _authorizationProvider = authorizationProvider;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            _log4net.Info(" Http GET Request From: " + nameof(AuthTokenController));
            string token = _authorizationProvider.GetJsonWebToken();
            if (token == null)
            {
                return BadRequest(token);
            }
            else
            {
                return Ok(token);
            }

        }
    }
}
