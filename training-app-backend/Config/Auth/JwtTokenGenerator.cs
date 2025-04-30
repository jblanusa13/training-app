using FluentResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainingApp.DTO;
using TrainingApp.Model;

namespace TrainingApp.Config.Auth
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly string _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "xWHYazaKIMfQ560Wa1xZhy2WVKVv9ajD";
        private readonly string _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "training";
        private readonly string _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "training-front.com";

        public Result<AuthResponseDto> GenerateAccessToken(User user)
        {
            var authenticationResponse = new AuthResponseDto();

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", user.Id.ToString()),
            new("email", user.Email)
        };

            var jwt = CreateToken(claims, 60);
            authenticationResponse.Id = user.Id.ToString();
            authenticationResponse.AccessToken = jwt;
            return authenticationResponse;
        }

        private string CreateToken(IEnumerable<Claim> claims, double expirationTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetUserIdFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken?.Payload != null && jsonToken.Payload.TryGetValue("id", out var userId))
            {
                if (userId is string userIdString)
                {
                    return userIdString;
                }
            }
            return "";
        }

        public string GetUserEmailFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken?.Payload != null && jsonToken.Payload.TryGetValue("email", out var userEmail))
            {
                if (userEmail is string userEmailString)
                {
                    return userEmailString;
                }
            }

            return "";
        }
    }
}
