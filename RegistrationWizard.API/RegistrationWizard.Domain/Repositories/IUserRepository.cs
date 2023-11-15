using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user, CancellationToken ct);
        
        Task<bool> CheckLoginExistAsync(string login, CancellationToken ct);
        
        Task<User?> GetAsync(string login, CancellationToken ct);

    }
}
