using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Models;
using RegistrationWizard.Services.Interfaces;

namespace RegistrationWizard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IRegionService regionService;

        RegistrationController(IUserService userService, IRegionService regionService)
        {
            this.userService = userService;
            this.regionService = regionService;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] UserModel newUser)
        {
            var userEntity = userService.Create(newUser);

            return Ok(userEntity.UserId);
        }

        // step2
        [HttpPost]
        public ActionResult UpdateUserCountry(long userId, long countryId, long provinceId)
        {
            var user = userService.Get(userId);
            user.CountryId = countryId;
            user.ProvinceId = provinceId;

            regionService.UpdateUserLocation(user);
            return Ok();
        }

        [HttpGet]
        public ActionResult IsUserNameExist(string name)
        {
            var result = userService.IsUserNameExist(name);

            return Ok(result);
        }
    }
}
