using TaskMangmentAPI.Infrastructure.DTOs;

namespace TaskMangmentAPI.Services.IServices
{
    public interface ITaskServices
    {
        Task<ResponseModel<object>> AddNewTaskToDB(NewTaskDto model);
        Task<ResponseModel<object>> UpdateTaskToDB(UpdateTaskDto model);
        Task<ResponseModel<object>> DeleteTaskToDB(string taskId);
        Task<ResponseModel<IList<TaskDto>>> GetTaskListByAccountId(string accountId);
    }
}
