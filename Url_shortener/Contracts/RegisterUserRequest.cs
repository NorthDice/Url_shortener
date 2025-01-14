using System.ComponentModel.DataAnnotations;

namespace Url_shortener.Contracts
{
    public record RegisterUserRequest(
        [Required] string Username,
        [Required] string Password,
        [Required] string Email);
}
