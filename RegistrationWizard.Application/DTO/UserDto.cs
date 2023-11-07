namespace RegistrationWizard.Application.DTO
{
    public record UserDto(long userId, string login, string passwordHash, long? countryId, long? provinceId);
}
