namespace RegistrationWizard.Domain.Entities
{
    public class Country
    {
        public Country() 
        { 
            Provinces = new List<Province>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = "";

        public IReadOnlyCollection<Province> Provinces { get; set; }
    }
}
