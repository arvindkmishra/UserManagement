using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Messaging;
using UserManagement.Infrastructure.Services;

namespace UserManagement.Core
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddHostedService<UserCreationConsumer>();
            services.AddHostedService<UserUpdateConsumer>();
            services.AddHostedService<UserDeactivationConsumer>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
