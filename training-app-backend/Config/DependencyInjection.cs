using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using TrainingApp.Config.Auth;
using TrainingApp.Config.Mapper;
using TrainingApp.Data;
using TrainingApp.Data.Repository;
using TrainingApp.Data.Repository.IRepository;
using TrainingApp.Service;
using TrainingApp.Service.IService;

namespace TrainingApp.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection SetupDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(TrainingProfile).Assembly);
            SetupServices(services);
            SetupRepository(services, configuration);
            return services;
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        }

        private static void SetupRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<TrainingContext>(opt =>
                        opt.UseNpgsql(configuration.GetConnectionString("Database")));
        }
    }
}
