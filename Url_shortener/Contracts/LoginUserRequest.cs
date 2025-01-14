using System.ComponentModel.DataAnnotations;

namespace Url_shortener.Contracts
{
    public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
}
