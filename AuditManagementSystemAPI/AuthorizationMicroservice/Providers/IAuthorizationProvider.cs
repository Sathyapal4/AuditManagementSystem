using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Providers
{
    public interface IAuthorizationProvider
    {
        public string GetJsonWebToken();
    }
}
