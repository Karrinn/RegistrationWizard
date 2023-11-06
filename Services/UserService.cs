using RegistrationWizard.Entities;
using RegistrationWizard.Models;
using RegistrationWizard.Services.Interfaces;
using RegistrationWizard.Database;

namespace RegistrationWizard.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext dbContext;

        public UserService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Create(UserModel newUser)
        {
            var newUserEntity = new User
            {
                Login = newUser.Login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
            };

            dbContext.Users.Add(newUserEntity);
            dbContext.SaveChanges();

            return newUserEntity;
        }

        public User Get(long userId)
        {
            return dbContext.Users.FirstOrDefault(s => s.UserId == userId);
        }

        public bool IsUserNameExist(string name)
        {
            return dbContext.Users.Any(a => a.Equals(name));
        }
    }
}
