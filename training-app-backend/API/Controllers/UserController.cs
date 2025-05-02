using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.API.DTO;
using TrainingApp.Core.Service.IService;

namespace TrainingApp.API.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(string id)
        {
            var result = _userService.GetById(id);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserRegistrationResponseDto> Register([FromBody] UserRegistrationDto registrationDto)
        {
            var result = _userService.Register(registrationDto);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<AuthResponseDto> Login([FromBody] UserLoginDto loginDto)
        {
            var result = _userService.Login(loginDto);
            return CreateResponse(result);
        }

    }
}
