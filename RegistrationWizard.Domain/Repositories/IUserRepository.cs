using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Domain.Repositories
{
    public interface IUserRepository
    {
        User? Get(long userId);
        void Create(User user);
        void Delete(User user);

        Task<User?> GetAsync(long userId, CancellationToken ct);
        Task CreateAsync(User user, CancellationToken ct);
        Task DeleteAsync(User user, CancellationToken ct);
    }
}
