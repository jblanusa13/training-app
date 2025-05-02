using FluentResults;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;

namespace TrainingApp.Config.Auth
{
    public interface ITokenGenerator
    {
        Result<AuthResponseDto> GenerateAccessToken(User user);
        string GetUserIdFromToken(string jwtToken);
        string GetUserEmailFromToken(string jwtToken);
    }
}
