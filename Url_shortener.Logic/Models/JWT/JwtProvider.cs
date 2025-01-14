using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Interfaces;

namespace Url_shortener.Logic.Models.JWT
{
    public class JwtProvider : IJwtProvider
    {

        public JwtProvider()
        {

        }

        public string GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
