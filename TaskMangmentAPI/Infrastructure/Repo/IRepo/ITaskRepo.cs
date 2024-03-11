using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Repo.IRepo
{
    public interface ITaskRepo
    {
        List<UsersTask> GetOrgnaizationAccountListByAccountId(string id);
        bool Put(UsersTask usersTask);
        Task<bool> Post(UsersTask usersTask);
        Task<bool> Delete(UsersTask usersTask);
    }
}
