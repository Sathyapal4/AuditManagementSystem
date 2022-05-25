using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repositories
{
    public interface IAuthorizationRepository
    {
        public string GenerateJWT();
    }
}
