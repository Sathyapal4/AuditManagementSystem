using AuthorizationMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Providers
{
    public class AuthorizationProvider:IAuthorizationProvider
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationProvider));
        public AuthorizationProvider(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }
        public string GetJsonWebToken()
        {
            _log4net.Info(" GetJsonWebToken method of AuthProvider Called ");
            string token = _authorizationRepository.GenerateJWT();
            return token;
        }
    }
}
