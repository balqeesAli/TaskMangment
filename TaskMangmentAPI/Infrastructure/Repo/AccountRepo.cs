using Microsoft.EntityFrameworkCore;
using TaskMangmentAPI.Context;
using TaskMangmentAPI.Repo.IRepo;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Repo
{
    public class AccountRepo : IAccountRepo
    { 
        private readonly TaskMangmentDbContext _db;

        public AccountRepo(TaskMangmentDbContext db)
        {
            _db = db;
        }

        public async Task<Account?> GetAccountByIdAsync(string id)
        {
            return await _db.Accounts.FirstOrDefaultAsync(acc => acc.Id.ToString() == id.ToLower());
        }
        public async Task<Account?> GetAccountByEmailAsync(string email)
        {
            return await _db.Accounts.FirstOrDefaultAsync(acc => acc.Email == email);
        }

        public async Task<bool> Post(Account account)
        {
            try
            {
                await _db.Accounts.AddAsync(account);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
