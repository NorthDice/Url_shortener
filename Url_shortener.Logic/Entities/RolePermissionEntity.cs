using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Url_shortener.Logic.Entities
{
    public class RolePermissionEntity
    {
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }

        public int PermissionId { get; set; }
        public PermissionEntity Permission { get; set; }

    }
}
