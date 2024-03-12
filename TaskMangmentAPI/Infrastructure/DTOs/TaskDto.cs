using System.ComponentModel.DataAnnotations;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class TaskDto
    { 
        public Guid Id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string status { get; set; }
         
    }
}
