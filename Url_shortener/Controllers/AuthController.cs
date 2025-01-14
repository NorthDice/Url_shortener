using Microsoft.AspNetCore.Mvc;
using Url_shortener.Contracts;

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

        public IActionResult Login(LoginUserRequest request)
        {
            return View();
        }
    }
}
