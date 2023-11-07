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
            logger.LogInformation("Seeding data...");

            var countries = new List<Country>()
            {
                new Country { Id = 1, Name = "Russia" },
                new Country { Id= 2, Name = "USA" },
            };

            await dbContext.Countries.AddRangeAsync(countries, cancellationToken);

            var provinces = new List<Province>()
            {
                new Province { Name = "Moscow", CountryId = 1 },
                new Province { Name = "St. Petersburg", CountryId = 1 },
                new Province { Name = "Kazan", CountryId = 1 },
                new Province { Name = "Washington D.C.", CountryId = 2 },
                new Province { Name = "New-York", CountryId = 2 },
                new Province { Name = "Los Angeles", CountryId = 2 },
            };

            await dbContext.Provinces.AddRangeAsync(provinces, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Seeding data has been completed");
        }
    }
}
