using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Url_shortener.Application.Services;
using Url_shortener.Contracts;
using Url_shortener.Logic.Interfaces;
using Url_shortener.Logic.Models.Url;
using Url_shortener.Persistence.Data;

namespace Url_shortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlShorteningService _urlShorteningService;
        private readonly ApplicationDbContext _dbContext;

        public UrlController(IUrlShorteningService urlShorteningService, ApplicationDbContext dbContext)
        {
            _urlShorteningService = urlShorteningService;
            _dbContext = dbContext;
        }

     
        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequest request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
            {
                return BadRequest("The specified URL is invalid.");
            }

            var code = await _urlShorteningService.GenerateUniqueCodeAsync();

            var shortenedUrl = new UrlManagment
            {
                OriginalUrl = request.Url,
                Code = code,
                ShortenedUrl = $"{Request.Scheme}://{Request.Host}/{code}",
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Urls.Add(shortenedUrl);
            await _dbContext.SaveChangesAsync();

            return Ok(shortenedUrl.ShortenedUrl);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string code)
        {
            var shortenedUrl = await _dbContext
                .Urls
                .SingleOrDefaultAsync(s => s.Code == code);

            if (shortenedUrl == null)
            {
                return NotFound("URL not found.");
            }

            return Redirect(shortenedUrl.OriginalUrl);
        }
    }

}
