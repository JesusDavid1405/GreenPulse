using Business.CustomJWT;
using Business.Interfaces;
using Business.Interfaces.Implements;
using Business.Services;

namespace Web.Extensions
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IToken, TokenBusiness>();
            services.AddScoped<IUserPlantServices, UserPlantServices>();
            services.AddScoped<ISensorDeviceServices, SensorDeviceServices>();
            services.AddScoped<ISensorReadingServices, SensorReadingServices>();
            services.AddScoped<IPlantSpeciesServices, PlantSpeciesServices>();
            services.AddScoped<IPlantCategoryServices, PlantCategoryServices>();
            services.AddScoped<INotificationServices, NotificationServices>();

            return services;
        }
    }
}
