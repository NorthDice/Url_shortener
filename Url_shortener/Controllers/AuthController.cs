using Microsoft.AspNetCore.Mvc;

namespace Url_shortener.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {

        public AuthController()
        {
            
        }

        public IActionResult Register(RegisterUserRequest request)
        {
            return View();
        }
    }
}
