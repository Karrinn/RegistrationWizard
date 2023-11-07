using FastEndpoints;
using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Endpoints
{
    public class GetIsLoginExistEndpoint : Endpoint<GetIsLoginExists, bool>
    {
        private readonly IUserRepository userRepository;

        public override void Configure()
        {
            Get("/check-login/{login:string}");
            AllowAnonymous();
        }

        public GetIsLoginExistEndpoint(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task HandleAsync(GetIsLoginExists req, CancellationToken ct)
        {
            var provinces = await userRepository.IsLoginExistAsync(req.Login, ct);
            if (provinces)
            {
                await SendOkAsync(true, ct);
                return;
            }

            await SendOkAsync(false, ct);
        }
    }
}
