using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationWizard.Domain.Repositories;
using RegistrationWizard.Infrastructure.Database;
using RegistrationWizard.Infrastructure.Repositories;

namespace RegistrationWizard.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnectionString") 
                ?? throw new ArgumentNullException("Sqlite connection string is missing.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString,
                    sqlOpts => sqlOpts.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name))
            );
            services.AddTransient<IDataSeeder, DataSeeder>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddCors(opts => { opts.AddDefaultPolicy(p => p.WithOrigins("*")); });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseCors();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            return app;
        }

        public static async Task SeedDatabaseAsync(this IApplicationBuilder app, CancellationToken ct = default)
        {
            await using var scope = app
                .ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateAsyncScope();

            var dbSeed = scope
                .ServiceProvider
                .GetRequiredService<IDataSeeder>();

            await dbSeed.SeedAsync(ct);
        }
    }
}
