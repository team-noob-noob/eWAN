using System.ComponentModel.DataAnnotations;

namespace eWAN.WebApi.UseCases.Register
{
    public sealed class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
