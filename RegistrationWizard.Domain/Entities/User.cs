namespace RegistrationWizard.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public int? ProvinceId { get; set; }
        public Province? Province { get; set; }
    }
}
