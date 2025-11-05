using Entity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class DatabaseServiceExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
