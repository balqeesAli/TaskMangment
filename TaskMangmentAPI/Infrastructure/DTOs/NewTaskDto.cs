using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class NewTaskDto
    {  
        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string AccountId { get; set; } 
    }
}
