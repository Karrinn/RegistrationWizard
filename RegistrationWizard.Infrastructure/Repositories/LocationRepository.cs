using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public LocationRepository() { }

        public Task<List<Country>> GetCountriesAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<List<Province>> GetCountryProvincesAsync(long countryId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
