using AutoMapper;
using TrainingApp.DTO;
using TrainingApp.Model;

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
