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
    [Route("[controller]")]
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
        public async Task<IActionResult> CreateShortenedUrl([FromBody] ShortenUrlRequest request)
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
                ShortenedUrl = $"{Request.Scheme}://{Request.Host}/Url/{code}",
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

        [HttpGet("AllUrls")]
        public async Task<IActionResult> GetAllUrls()
        {
            var urls = await _dbContext.Urls.ToListAsync();

            return Ok(urls.Select(url => new GetUrlsResponse(url.Id, url.OriginalUrl, url.ShortenedUrl, url.UserId, url.CreatedAt)).ToList());
        }

        [HttpDelete("DeleteUrl")]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var urlToDelete = await _dbContext.Urls.SingleOrDefaultAsync(url => url.Id == id);

            if (urlToDelete == null)
            {
                return NotFound("URL not found.");
            }

            _dbContext.Urls.Remove(urlToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent(); 
        }




    }

}
