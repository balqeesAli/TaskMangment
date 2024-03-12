using System.ComponentModel.DataAnnotations;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class RegistrationDto
    {  
        [Required]
        public string name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; set; }
    }
}
