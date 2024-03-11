using TaskMangmentAPI.Context;
using TaskMangmentAPI.Repo.IRepo;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Repo
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskMangmentDbContext _db;

        public TaskRepo(TaskMangmentDbContext db)
        {
            _db = db;
        }
         
        public List<UsersTask> GetOrgnaizationAccountListByAccountId(string id)
        {
            return _db.UsersTasks.Where(x => x.AccountId.ToString() == id).ToList();
        }

        public bool Put(UsersTask usersTask)
        {
            try
            {
                _db.Update(usersTask);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Post(UsersTask usersTask)
        {
            try
            {
                await _db.UsersTasks.AddAsync(usersTask);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(UsersTask usersTask)
        {
            try
            {
                _db.UsersTasks.Remove(usersTask);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
