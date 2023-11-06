namespace RegistrationWizard.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }

        public long ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
