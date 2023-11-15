using Microsoft.Extensions.DependencyInjection;
using RegistrationWizard.Application.Services;

namespace RegistrationWizard.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
