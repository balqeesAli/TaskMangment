using Microsoft.EntityFrameworkCore;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Context
{
    public class TaskMangmentDbContext : DbContext
    { 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UsersTask> UsersTasks { get; set; }

        public TaskMangmentDbContext(DbContextOptions<TaskMangmentDbContext> options) : base(options)
        {
        }
    }
}
