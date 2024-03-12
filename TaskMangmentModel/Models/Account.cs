using System.ComponentModel.DataAnnotations;

namespace TaskMangmentModel.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string HashPassword { get; set; }
        public Account()
        {

        }
    }
}