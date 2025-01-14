using Microsoft.AspNetCore.Mvc;
using Url_shortener.Application.Services;
using Url_shortener.Contracts;

namespace Url_shortener.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        

        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);
            return View();
        }

        public IActionResult Login(LoginUserRequest request)
        {
            return View();
        }
    }
}
