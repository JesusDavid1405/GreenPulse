using Data.Interfaces.IDataBasic;
using Data.Interfaces.IDataImplement;
using Data.Repository;
using Data.Services;

namespace Web.Extensions
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataBasic<>), typeof(DataGeneric<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlantSpeciesRepository, PlantSpeciesRepository>();
            services.AddScoped<IUserPlantRepository, UserPlantRepository>();
            services.AddScoped<ISensorReadingRepository, SensorReadingRepository>();
            services.AddScoped<ISensorDeviceRepository, SensorDeviceRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
