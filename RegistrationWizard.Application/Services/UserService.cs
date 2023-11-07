using RegistrationWizard.Application.Requests;
using RegistrationWizard.Domain.Repositories;
using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Application.Exceptions;

namespace RegistrationWizard.Application.Services
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUser user, CancellationToken ct);
        Task<bool> VerifyAsync(VerifyUser user, CancellationToken ct);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterUser user, CancellationToken ct = default)
        {
            var loginExist = await userRepository.CheckLoginExistAsync(user.Login, ct);
            if (loginExist)
            {
                throw new UserAlreadyExistException();
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var userEntity = new User
            {
                Login = user.Login,
                Salt = salt,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password, salt),
                CountryId = user.CountryId,
                ProvinceId = user.ProvinceId,
            };

            await userRepository.CreateAsync(userEntity, ct);
        }

        public async Task<bool> VerifyAsync(VerifyUser user, CancellationToken ct = default)
        {
            var u = await userRepository.GetAsync(user.Login, ct);
            return BCrypt.Net.BCrypt.Verify(user.Password, u.PasswordHash);
        }
    }
}
