using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Url_shortener.Logic.Interfaces
{
    public interface IUrlShorteningService
    {
        Task<string> GenerateUniqueCodeAsync();
    }
}
