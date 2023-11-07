using RegistrationWizard.Application.DTO;
using RegistrationWizard.Domain.Entities;

namespace RegistrationWizard.Application
{
    public static class Mappings
    {
        public static UserDto AsDto(this User entity)
        {
            return new UserDto(entity.UserId, entity.Login, entity.PasswordHash, entity.CountryId, entity.ProvinceId);
        }

        public static CountryDto AsDto(this Country entity)
        {
            return new CountryDto(entity.Id, entity.Name);
        }
        public static ProvinceDto AsDto(this Province entity)
        {
            return new ProvinceDto(entity.Id, entity.Name, entity.CountryId);
        }
    }
}
