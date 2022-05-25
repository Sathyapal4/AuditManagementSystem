using AuditManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortal.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
            new User{Name = "User1", Password ="Password1" },
            new User{Name = "User2", Password ="Password2" },
            new User{Name = "User3", Password ="Password3" },
            new User{Name = "User4", Password ="Password4" }
            };
            return users;
        }
    }
}
