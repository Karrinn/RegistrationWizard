using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Domain.Repositories;

namespace RegistrationWizard.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public User? Get(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(long userId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsLoginExistAsync(string login, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
