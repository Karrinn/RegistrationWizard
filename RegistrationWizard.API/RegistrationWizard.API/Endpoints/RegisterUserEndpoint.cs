using FastEndpoints;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Application.Services;

namespace RegistrationWizard.API.Endpoints
{
    public class RegisterUserEndpoint : Endpoint<RegisterUser>
    {
        private readonly IUserService userService;

        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public RegisterUserEndpoint(IUserService userService)
        {
            this.userService = userService;
        }

        public override async Task HandleAsync(RegisterUser req, CancellationToken ct)
        {
            await userService.RegisterAsync(req, ct);

            await SendOkAsync(ct);
        }
    }
}
