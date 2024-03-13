using System.ComponentModel.DataAnnotations;

namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public int? TaskNo { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Status { get; set; }
        public TaskDto(){}
        public TaskDto(int taskNo, TaskDto taskDto)
        {
            this.TaskId = taskDto.TaskId;
            this.TaskNo = taskNo;
            this.Title = taskDto.Title;
            this.Summary = taskDto.Summary;
            this.Status = taskDto.Status;  
        }
    }
}
