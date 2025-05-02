using AutoMapper;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;

namespace TrainingApp.Config.Mapper
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile() 
        { 
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
