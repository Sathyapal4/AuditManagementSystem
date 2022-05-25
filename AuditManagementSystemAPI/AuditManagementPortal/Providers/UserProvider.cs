using AuditManagementPortal.Models;
using AuditManagementPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CheckUser(User user)
        {
            List<User> users = _userRepository.GetUsers();

            foreach(User u in users) 
            {
                if (user.Name == u.Name && user.Password == u.Password) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
