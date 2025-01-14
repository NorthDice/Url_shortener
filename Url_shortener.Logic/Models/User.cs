﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Url_shortener.Logic.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        [Key]
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

        public static User Create(Guid id, string username, string passwordHash, string email)
        {
            return new User(id, username, passwordHash, email);
        }
    }
}
