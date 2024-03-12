using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Repo.IRepo
{
    public interface IAccountRepo
    {
        Task<Account?> GetAccountByIdAsync(string id);
        Task<Account?> GetAccountByEmailAsync(string email);
        Task<bool> Post(Account account);
    }
}
