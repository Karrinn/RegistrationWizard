namespace RegistrationWizard.Domain.Entities
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Province> Provinces { get; set; } = new();
    }
}
