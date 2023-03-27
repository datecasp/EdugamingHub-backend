using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
