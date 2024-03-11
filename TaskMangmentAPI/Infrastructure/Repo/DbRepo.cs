using TaskMangmentAPI.Context;
using TaskMangmentAPI.Infrastructure.Repo.IRepo;
using TaskMangmentAPI.Repo;
using TaskMangmentAPI.Repo.IRepo;

namespace TaskMangmentAPI.Infrastructure.Repo
{
    public class DbRepo : IDbRepo
    {
        private readonly TaskMangmentDbContext _db;
        public DbRepo(TaskMangmentDbContext db)
        {
            _db = db;
            AccountRepo = new AccountRepo(db);
            TaskRepo = new TaskRepo(db); 
        }

        public IAccountRepo AccountRepo{ get; }
        public ITaskRepo TaskRepo { get; } 
        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<bool> SaveDbAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
