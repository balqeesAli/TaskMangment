using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Repo.IRepo
{
    public interface ITaskRepo
    {
        Task<IList<TaskDto>> GetTaskListByAccountId(string id);
        Task<UsersTask> GetTaskByTaskId(string id);
        bool Put(UsersTask usersTask);
        Task<bool> Post(UsersTask usersTask);
        Task<bool> Delete(UsersTask usersTask);
    }
}
