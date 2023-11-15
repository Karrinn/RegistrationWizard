using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Domain.Entities;
using RegistrationWizard.Domain.Repositories;
using RegistrationWizard.Infrastructure.Database;

namespace RegistrationWizard.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(User user, CancellationToken ct)
        {
            await dbContext.Users.AddAsync(user, ct);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckLoginExistAsync(string login, CancellationToken ct)
        {
            return await dbContext.Users.AnyAsync(x => x.Login == login, ct);
        }

        public async Task<User?> GetAsync(string login, CancellationToken ct)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Login == login, ct);
        }

        //todo delete async
    }
}
