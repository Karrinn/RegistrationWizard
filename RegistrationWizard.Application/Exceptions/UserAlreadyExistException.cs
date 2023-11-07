namespace RegistrationWizard.Application.Exceptions
{
    public class UserAlreadyExistException : AppException
    {
        public override string Code => "login_exists";

        public UserAlreadyExistException() : base("User with this login already exists.")
        {
        }
    }
}
