using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Enums;
using Url_shortener.Logic.Models;

namespace Url_shortener.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<HashSet<Permissions>> GetUserPermissions(Guid userId);
    }
}
