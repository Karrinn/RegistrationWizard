using RegistrationWizard.Models;
using RegistrationWizard.Entities;

namespace RegistrationWizard.Services.Interfaces
{
    public interface IUserService
    {
        User Create(UserModel newUser);
        bool IsUserNameExist(string name);
        User Get(long userId);
    }
}
