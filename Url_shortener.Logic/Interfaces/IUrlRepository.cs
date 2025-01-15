using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Models.Url;

namespace Url_shortener.Logic.Interfaces
{
    public interface IUrlRepository
    {
        Task<UrlManagment> AddUrlAsync(UrlManagment url);
        Task<IEnumerable<UrlManagment>> GetUrlsByUserIdAsync(Guid id);
        Task<UrlManagment> GetUrlByIdAsync(Guid id);
        Task<bool> UrlExistsAsync(string code);
    }

}
