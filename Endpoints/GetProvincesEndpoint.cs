using FastEndpoints;
using RegistrationWizard.Application;
using RegistrationWizard.Application.DTO;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Endpoints
{
    public class GetProvincesEndpoint : Endpoint<GetProvinces, IEnumerable<ProvinceDto>>
    {
        private readonly ILocationRepository locationRepository;

        public override void Configure()
        {
            Get("/country/{countryId:long}");
            AllowAnonymous();
        }

        public GetProvincesEndpoint(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public override async Task HandleAsync(GetProvinces req, CancellationToken ct)
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
