using FastEndpoints;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.API.Endpoints
{
    public class RegisterUserEndpoint : Endpoint<RegisterUser>
    {
        private readonly ILocationRepository locationRepository;

        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public RegisterUserEndpoint(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public override async Task HandleAsync(RegisterUser r, CancellationToken ct)
        {
            await SendOkAsync(ct);
        }
    }
}
