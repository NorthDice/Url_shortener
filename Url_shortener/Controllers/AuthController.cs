using Microsoft.AspNetCore.Mvc;
using Url_shortener.Application.Services;
using Url_shortener.Contracts;

namespace Url_shortener.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.Username, request.Email, request.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.Login(request.Email, request.Password);

                Response.Cookies.Append("Shortener", token);
            }
            return Ok();
        }
    }
}
