using TaskMangmentAPI.Services.IServices;

namespace TaskMangmentAPI.Infrastructure.DependancyInjection
{
    public static class DependancyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration, string maalyDbConnectionStringKey, string businessMaalyDbConnectionStringKey)
        {
            var secretKey = configuration.GetValue<string>("JWT:Secret");
            services.AddControllers();
            services.AddControllersWithViews();

            //services.AddDbContext<TaskMangmentDbContext>((provider, options) =>
            //{
            //    var dynamoHelper = provider.GetRequiredService<DynamoDBConfigurationHelper>();
            //    var connectionString = dynamoHelper.GetStringAsync(maalyDbConnectionStringKey).GetAwaiter().GetResult();
            //    options.UseSqlServer(connectionString);
            //}); 

            //services.AddScoped<IAccountRepo, AccountRepo>();
            //services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddScoped<IAuthServices, IAuthServices>();
            services.AddScoped<ITaskServices, ITaskServices>(); 
              
            services.AddHttpContextAccessor(); 

            services.AddControllers().AddNewtonsoftJson
                (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return services;
        } 
    }
}
