using FluentResults;
using TrainingApp.DTO;

namespace TrainingApp.Service.IService
{
    public interface IUserService
    {
        Result<UserDto> GetById(string id);
        Result<UserRegistrationResponseDto> Register(UserRegistrationDto registrationDto);
        Result<AuthResponseDto> Login(UserLoginDto loginDto);
    }
}
