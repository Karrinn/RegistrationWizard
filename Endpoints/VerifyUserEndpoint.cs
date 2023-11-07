using FastEndpoints;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Application.Services;

namespace RegistrationWizard.API.Endpoints
{
    public class VerifyUserEndpoint : Endpoint<VerifyUser>
    {
        private readonly IUserService userService;

        public override void Configure()
        {
            Post("/users/verify");
            AllowAnonymous();
        }

        public VerifyUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task HandleAsync(VerifyUser req, CancellationToken ct)
        {
            await userService.VerifyAsync(req, ct);

            await SendOkAsync(ct);
        }
    }
}
