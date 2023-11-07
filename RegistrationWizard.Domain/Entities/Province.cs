namespace RegistrationWizard.Domain.Entities
{
    public class Province
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
