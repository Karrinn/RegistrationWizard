using Microsoft.Extensions.DependencyInjection;
using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Domain;

namespace RegistrationWizard.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            return services;
        }
    }
}
