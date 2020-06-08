using System.ComponentModel.DataAnnotations;

namespace eWAN.WebApi.UseCases.LogIn
{
    public class LogInRequest
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
