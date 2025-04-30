using AutoMapper;
using FluentResults;

namespace TrainingApp.Config.Mapper
{
    /// <typeparam name="TDto">Type of output data transfer object.</typeparam>
    /// <typeparam name="TDomain">Type of domain object that maps to TDto</typeparam>
    public abstract class Mapper<TDto, TDomain>
    {
        private readonly IMapper _mapper;

        protected Mapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TDomain MapToDomain(TDto dto)
        {
            return _mapper.Map<TDomain>(dto);
        }


        protected TDto MapToDto(TDomain domain)
        {
            return _mapper.Map<TDto>(domain);
        }
    }
}
