using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Domain.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Country>> GetCountriesAsync(CancellationToken ct);
        Task<List<Province>> GetCountryProvincesAsync(long countryId, CancellationToken ct);

    }
}
