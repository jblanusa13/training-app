using System;
using TrainingApp.Data.Repository.IRepository;
using TrainingApp.DTO;
using TrainingApp.Service.IService;
using FluentResults;
using TrainingApp.Model;
using AutoMapper;
using TrainingApp.Config.Mapper;
using System.Security.Principal;
using System.Diagnostics;
using TrainingApp.Config.Auth;
using System.Net;

namespace TrainingApp.Service
{
    public class UserService : Mapper<UserDto, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        public UserService(IUserRepository userRepository,
            IMapper mapper, 
            ITokenGenerator tokenGenerator) : base(mapper)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public Result<UserDto> GetById(string id)
        {
            try
            {
                var result = _userRepository.GetById(new Guid(id));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(new Error("Accessed resource not found.")
                    .WithMetadata("code", 404))
                    .WithError(e.Message);
            }
        }

        public Result<UserRegistrationResponseDto> Register(UserRegistrationDto registrationDto)
        {
            try
            {
                var user = _userRepository.Create(new User(
                    registrationDto.Name,
                    registrationDto.LastName,
                    registrationDto.Email,
                    PasswordHasher.Hash(registrationDto.Password)));

                return new UserRegistrationResponseDto(user.Id, user.Name, user.LastName, user.Email);
            }
            catch (Exception e)
            {
                return Result.Fail(new Error("Invalid argument")
                    .WithMetadata("code", 400))
                    .WithError(e.Message);
            }
        }

        public Result<AuthResponseDto> Login(UserLoginDto loginDto)
        {
            try
            {
                var user = _userRepository.GetByEmail(loginDto.Email);
                if (user == null || !PasswordHasher.Matches(loginDto.Password, user.Password))
                    return Result.Fail(new Error("User not found!")
                    .WithMetadata("code", 404));
                var tokens = _tokenGenerator.GenerateAccessToken(user);
                return tokens;
            }
            catch (Exception e)
            {
                return Result.Fail(new Error(e.Message));
            }

        }
    }
}
