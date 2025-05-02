using FluentResults;
using TrainingApp.API.DTO;

namespace TrainingApp.Core.Service.IService
{
    public interface IUserService
    {
        Result<UserDto> GetById(string id);
        Result<UserRegistrationResponseDto> Register(UserRegistrationDto registrationDto);
        Result<AuthResponseDto> Login(UserLoginDto loginDto);
    }
}
