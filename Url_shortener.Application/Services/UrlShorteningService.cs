using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models;
using Url_shortener.Logic.Models.Url;
using Url_shortener.Persistence.Data;


namespace Url_shortener.Application.Services
{
    public class UrlShorteningService(ApplicationDbContext dbContext) : IUrlShorteningService
    {
        private readonly Random _random = new();

        public async Task<string> GenerateUniqueCodeAsync()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Alphabet.Length;

            while (true)
            {
                for (var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (!await dbContext.Urls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }

}
