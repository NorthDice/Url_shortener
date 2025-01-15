using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models;


namespace Url_shortener.Application.Services
{
    public class UrlShorteningService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly Random _random = new Random();

        public UrlShorteningService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string> GeneratingUniqueCodeAsync()
        {
            var codeChars = new char[ShortLinkSettings.Length];

            while(true)
            {
                for (int i = 0; i < ShortLinkSettings.Length; i++)
                {
                    int randomIndex = _random.Next(ShortLinkSettings.Alphabet.Length - 1);

                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (!await _urlRepository.UrlExistsAsync(code))
                {
                    return code;
                }
            }
            


        }
    }
}
