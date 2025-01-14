using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCrypt.Net;
using System.Threading.Tasks;
using Url_shortener.Logic.Interfaces;

namespace Url_shortener.Logic.Models
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => 
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
