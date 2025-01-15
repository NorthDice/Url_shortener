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


namespace Url_shortener.Application.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly Random _random = new Random();
        private readonly IHttpContextAccessor _httpContextAccessor;

        
        public UrlShorteningService(IUrlRepository urlRepository, IHttpContextAccessor httpContextAccessor)
        {
            _urlRepository = urlRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GenerateUniqueCodeAsync()
        {
            var codeChars = new char[ShortLinkSettings.Length];

            while (true)
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

        public async Task<UrlManagment> ShortenUrlAsync(string originalUrl)
        {
            if (!Uri.TryCreate(originalUrl, UriKind.Absolute, out _))
            {
                throw new ArgumentException("The specified URL is invalid.");
            }

            
            var code = await GenerateUniqueCodeAsync();

            
            while (await _urlRepository.UrlExistsAsync(code))
            {
                code = await GenerateUniqueCodeAsync();
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("HttpContext is null.");
            }

            
            var shortenedUrl = new UrlManagment
            {
                Id = Guid.NewGuid(),
                OriginalUrl = originalUrl,
                Code = code,
                ShortenedUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/api/{code}",
                CreatedAt = DateTime.UtcNow
            };

            
            await _urlRepository.AddUrlAsync(shortenedUrl);

            return shortenedUrl;
        }
    }

}
