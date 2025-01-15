using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Models.Url;

namespace Url_shortener.Logic.Interfaces
{
    public interface IUrlShorteningService
    {
        Task<string> GenerateUniqueCodeAsync();
        
    }
}
