using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TrainingApp.Config.Auth
{
    public static class AuthConfig
    {
        public static IServiceCollection ConfigureAuth(this IServiceCollection services)
        {
            ConfigureAuthentication(services);
           // ConfigureAuthorizationPolicies(services);
            return services;
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "GUIO9155CssUtSORCnFKLWihGlG5dYti";
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "training";
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "training-front.com";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("AuthenticationTokens-Expired", "true");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        private static void ConfigureAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("trainingPolicy", policy => policy.RequireRole("user"));

            });
        }

    }
}
