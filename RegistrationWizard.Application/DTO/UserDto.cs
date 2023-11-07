namespace RegistrationWizard.Application.DTO
{
    public record UserDto(int userId, string login, string passwordHash, int? countryId, int? provinceId);
}
