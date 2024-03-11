using System.ComponentModel.DataAnnotations;

namespace TaskMangmentModel.Models
{
    public class UsersTask
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public string AccountId { get; set; }
    }
}