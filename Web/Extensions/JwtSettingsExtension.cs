using Entity.Models.Implements;
using Microsoft.Extensions.Options;

namespace Web.Extensions
{
    public static class JwtSettingsExtension
    {
        public static IServiceCollection AddJwtSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<JwtSettings>>().Value);

            return services;
        }
    }
}
