using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.DTO;
using TrainingApp.Service.IService;

namespace TrainingApp.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(string id)
        {
            var result = _userService.GetById(id);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<UserRegistrationResponseDto> Register([FromBody] UserRegistrationDto registrationDto)
        {
            var result = _userService.Register(registrationDto);
            return CreateResponse(result);
        }


        [HttpPost("login")]
        public ActionResult<AuthResponseDto> Login([FromBody] UserLoginDto loginDto)
        {
            var result = _userService.Login(loginDto);
            return CreateResponse(result);
        }

    }
}
