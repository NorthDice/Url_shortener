using Microsoft.AspNetCore.Mvc;
using Url_shortener.Application.Services;

namespace Url_shortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : Controller
    {
        private readonly UrlService _urlService;

        public UrlController(UrlService urlService)
        {
            _urlService = urlService;
        }

        
    }
}
