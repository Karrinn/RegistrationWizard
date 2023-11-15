using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Infrastructure.Database
{
    public interface IDataSeeder
    {
        Task SeedAsync(CancellationToken cancellationToken);
    }

    public class DataSeeder : IDataSeeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<DataSeeder> logger;

        public DataSeeder(ApplicationDbContext dbContext, ILogger<DataSeeder> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Applying db migrations....");
            // Apply migrations
            await dbContext.Database.MigrateAsync(cancellationToken);

            // Seed data if no data in the db
            logger.LogInformation("Seeding data...");
            if (await dbContext.Countries.AnyAsync(cancellationToken))
            {
                return;
            }

            logger.LogInformation("Seeding data...");

            var countries = new List<Country>()
            {
                new Country { Name = "Russia" },
                new Country { Name = "USA" },
            };

            await dbContext.Countries.AddRangeAsync(countries, cancellationToken);

            var provinces = new List<Province>()
            {
                new Province { Name = "Moscow", Country = countries[0] },
                new Province { Name = "St. Petersburg", Country = countries[0] },
                new Province { Name = "Kazan", Country = countries[0] },
                new Province { Name = "Washington D.C.", Country = countries[1] },
                new Province { Name = "New-York", Country = countries[1] },
                new Province { Name = "Los Angeles", Country = countries[1] },
            };

            await dbContext.Provinces.AddRangeAsync(provinces, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Seeding data has been completed");
        }
    }
}
