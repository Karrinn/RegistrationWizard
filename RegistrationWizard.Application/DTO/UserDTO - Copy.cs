namespace RegistrationWizard.Application.DTO
{
    public record UserDTO(long userId, string login, string passwordHash, long countryId, long provinceId);
}
