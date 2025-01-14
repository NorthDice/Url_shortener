using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Models;

namespace Url_shortener.Logic.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
