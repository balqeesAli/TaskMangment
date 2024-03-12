using Microsoft.EntityFrameworkCore;
using TaskMangmentAPI.Context;
using TaskMangmentAPI.Infrastructure.Repo;
using TaskMangmentAPI.Infrastructure.Repo.IRepo;
using TaskMangmentAPI.Repo;
using TaskMangmentAPI.Repo.IRepo;
using TaskMangmentAPI.Services;
using TaskMangmentAPI.Services.IServices;

namespace TaskMangmentAPI.Infrastructure.DependancyInjection
{
    public static class DependancyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddControllers();
            services.AddControllersWithViews(); 

            var connectionString = configuration.GetConnectionString("TaskManagementDBConnection");
            services.AddDbContext<TaskMangmentDbContext>(x => x.UseSqlServer(connectionString));
             
            services.AddScoped<IDbRepo, DbRepo>();
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<ITaskServices, TaskServices>();

            services.AddHttpContextAccessor(); 

            services.AddControllers().AddNewtonsoftJson
                (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return services;
        } 
    }
}
