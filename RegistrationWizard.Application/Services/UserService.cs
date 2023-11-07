using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Application.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUser user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterUser user)
        {
            // todo get paswordHash

        }
    }
}
