using BusinessData;
using BusinessData.Interface;
using BusinessData.Services;
using Microsoft.EntityFrameworkCore;

namespace UplersTodo.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            services.AddScoped<ITodoRepository, TodoRepository>();
            
            return services;
        }
    }
}
