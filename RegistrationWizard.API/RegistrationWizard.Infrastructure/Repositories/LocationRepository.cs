using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Domain.Repositories;
using RegistrationWizard.Infrastructure.Database;

namespace RegistrationWizard.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Country>> GetCountriesAsync(CancellationToken ct)
        {
            return await dbContext
                .Countries
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<List<Province>> GetCountryProvincesAsync(int countryId, CancellationToken ct)
        {
            var country = await dbContext
                .Countries
                .AsNoTracking()
                .Include(x => x.Provinces)
                .SingleOrDefaultAsync(x => x.CountryId == countryId, ct);

            return country.Provinces.ToList();
        }
    }
}
