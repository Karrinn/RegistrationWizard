using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationWizard.Domain.Repositories;
using RegistrationWizard.Infrastructure.Database;
using RegistrationWizard.Infrastructure.Repositories;
using Serilog;

namespace RegistrationWizard.Infrastructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var connectionString = configuration.GetConnectionString("SqlLiteConnectionString") 
                ?? throw new ArgumentNullException("Sqlite connection string is missing.");

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlite(connectionString)
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddCors(opts => { opts.AddDefaultPolicy(p => p.WithOrigins("*")); });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging();
            app.UseCors();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            return app;
        }
    }
}
