using RegistrationWizard.Models;
using RegistrationWizard.Entities;

namespace RegistrationWizard.Services.Interfaces
{
    public interface IUserService
    {
        User Create(UserModel newUser);
        User Get(long userId);
    }
}
