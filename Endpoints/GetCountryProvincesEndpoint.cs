using FastEndpoints;
using RegistrationWizard.Application;
using RegistrationWizard.Application.DTO;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Endpoints
{
    public class GetCountryProvincesEndpoint : Endpoint<GetCountryProvincies, IEnumerable<ProvinceDto>>
    {
        private readonly ILocationRepository locationRepository;

        public override void Configure()
        {
            Get("/countries/{countryId}/provincies");
            AllowAnonymous();
        }

        public GetCountryProvincesEndpoint(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public override async Task HandleAsync(GetCountryProvincies req, CancellationToken ct)
        {
            var provinces = await locationRepository.GetCountryProvincesAsync(req.CountryId, ct);
            if (provinces is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(provinces.Select(s => s.AsDto()), ct);
        }
    }
}
