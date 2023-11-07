namespace RegistrationWizard.Domain.Entities
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
