using FastEndpoints;
using RegistrationWizard.Application;
using RegistrationWizard.Application.DTO;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Endpoints
{
    public class GetCounriesEndpoint : Endpoint<GetProvinces, IEnumerable<CountryDto>>
    {
        private readonly ILocationRepository locationRepository;

        public override void Configure()
        {
            Get("/countries");
            AllowAnonymous();
        }

        public GetCounriesEndpoint(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public override async Task HandleAsync(GetProvinces req, CancellationToken ct)
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
