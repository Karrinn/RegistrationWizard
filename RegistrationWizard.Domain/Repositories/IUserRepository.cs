using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Domain.Repositories
{
    public interface IUserRepository
    {
        User? Get(int userId);
        void Create(User user);
        void Delete(User user);

        Task<User?> GetAsync(int userId, CancellationToken ct);
        Task<bool> IsLoginExistAsync(string login, CancellationToken ct);
        Task CreateAsync(User user, CancellationToken ct);
        Task DeleteAsync(User user, CancellationToken ct);
    }
}
