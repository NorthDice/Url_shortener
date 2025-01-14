using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Application.Interfaces;
using Url_shortener.Logic.Enums;
using Url_shortener.Logic.Models;

namespace Url_shortener.Persistence.Data
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<HashSet<Permissions>> GetUserPermissions(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
