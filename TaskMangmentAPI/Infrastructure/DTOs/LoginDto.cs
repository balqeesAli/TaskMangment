using System.ComponentModel.DataAnnotations;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class loginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; set; }
    }
}
