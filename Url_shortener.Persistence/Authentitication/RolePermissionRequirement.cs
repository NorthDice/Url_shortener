using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Enums;

namespace Url_shortener.Persistence.Authentitication
{
    public class RolePermissionRequirement : IAuthorizationRequirement
    {
        public RolePermissionRequirement(Permissions[] permissions)
        {
            Permissions = permissions;
        }

        public Permissions[] Permissions { get; set; } = [];
    }
}
