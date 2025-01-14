using Microsoft.AspNetCore.Mvc;
using Url_shortener.Application.Services;
using Url_shortener.Contracts;

namespace Url_shortener.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.Username, request.Email, request.Password);
            return View();
        }

        public async Task<IResult> Login(LoginUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.Login(request.Email, request.Password);

                Response.Cookies.Append("Shortener", token);
            }
            return Results.Ok();
        }
    }
}
