using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Url_shortener.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user)
    }
}
