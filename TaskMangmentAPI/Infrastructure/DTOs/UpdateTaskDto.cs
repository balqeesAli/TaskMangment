using System.ComponentModel.DataAnnotations;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class UpdateTaskDto
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Status { get; set; } 
    }
}
