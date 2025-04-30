using FluentResults;
using TrainingApp.DTO;
using TrainingApp.Model;

namespace TrainingApp.Config.Auth
{
    public interface ITokenGenerator
    {
        Result<AuthResponseDto> GenerateAccessToken(User user);
        string GetUserIdFromToken(string jwtToken);
        string GetUserEmailFromToken(string jwtToken);
    }
}
