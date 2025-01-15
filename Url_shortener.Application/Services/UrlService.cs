using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url_shortener.Application.Interfaces;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models.Url;

namespace Url_shortener.Application.Services
{
    public class UrlService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IUserRepository _userRepository;

        public UrlService(IUrlRepository urlRepository, IUserRepository userRepository)
        {
            _urlRepository = urlRepository;
            _userRepository = userRepository;
        }

        public async Task<UrlManagment> AddUrlForUserAsync(string userEmail, string originalUrl, string shortenedUrl)
        {
            var user = await _userRepository.GetByEmail(userEmail);
            if (user == null) throw new Exception("User not found");

            var url = new UrlManagment
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortenedUrl,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow
            };

            return await _urlRepository.AddUrlAsync(url);
        }

        public async Task<IEnumerable<UrlManagment>> GetUrlsForUserAsync(int userId)
        {
            return await _urlRepository.GetUrlsByUserIdAsync(userId);
        }
    }
}
