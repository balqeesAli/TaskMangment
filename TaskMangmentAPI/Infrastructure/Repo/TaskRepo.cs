using Microsoft.EntityFrameworkCore;
using TaskMangmentAPI.Context;
using TaskMangmentAPI.Infrastructure.DTOs;
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
         
        public async Task<IList<TaskDto>> GetTaskListByAccountId(string id)
        {
            return await _db.UsersTasks
                .Where(x => x.AccountId.ToString() == id)
                .Select(x => new TaskDto { 
                Id = x.Id,
                title = x.title,
                Summary = x.Summary,
                status = x.status
                }).ToListAsync();
        }
        public async Task<UsersTask> GetTaskByTaskId(string id)
        {
            return await _db.UsersTasks.Where(x => x.Id.ToString() == id.ToLower()).FirstOrDefaultAsync();
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
