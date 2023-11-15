namespace RegistrationWizard.Application.Requests
{
    public class RegisterUser
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
    }
}