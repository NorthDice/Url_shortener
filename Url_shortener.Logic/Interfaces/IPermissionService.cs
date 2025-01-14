using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Enums;

namespace Url_shortener.Logic.Interfaces
{
    public interface IPermissionService
    {
        Task<HashSet<Permissions>> GetPermissionsAsync(Guid userId);
    }
}
