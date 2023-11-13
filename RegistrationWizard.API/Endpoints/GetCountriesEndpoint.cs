using FastEndpoints;
using RegistrationWizard.Application;
using RegistrationWizard.Application.DTO;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Endpoints
{
    public class GetCountriesEndpoint : EndpointWithoutRequest<IEnumerable<CountryDto>>
    {
        const int cacheDurationSec = 60*60*24; // 1 day
        private readonly ILocationRepository locationRepository;

        public override void Configure()
        {
            Get("/countries");
            AllowAnonymous();
            ResponseCache(cacheDurationSec);
        }

        public GetCountriesEndpoint(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var countries = await locationRepository.GetCountriesAsync(ct);
            if (countries is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(countries.Select(s => s.AsDto()), ct);
        }
    }
}
