using TaskMangmentAPI.Repo.IRepo;

namespace TaskMangmentAPI.Infrastructure.Repo.IRepo
{
    public interface IDbRepo
    {
        public IAccountRepo AccountRepo { get; }
        public ITaskRepo TaskRepo { get; }
        Task<bool> SaveDbAsync();
    }
}
