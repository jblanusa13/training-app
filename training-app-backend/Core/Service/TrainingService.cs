using FluentResults;
using System.Globalization;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;
using TrainingApp.Core.Service.IService;
using TrainingApp.Data.Repository;
using TrainingApp.Data.Repository.IRepository;

namespace TrainingApp.Core.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository) 
        { 
            _trainingRepository = trainingRepository;  
        }

        public Result<CreateTrainingResponseDto> CreateTraining(CreateTrainingDto trainingDto)
        {
            try
            {
                var training = _trainingRepository.Create(new Training(
                    trainingDto.Type.Id,
                    new Guid(trainingDto.UserId),
                    trainingDto.Duration,
                    trainingDto.Calories,
                    trainingDto.Difficulty,
                    trainingDto.Tiredness,
                    trainingDto.Notes,
                    DateTime.Parse(trainingDto.DateTime).ToUniversalTime()
                    ));

                return new CreateTrainingResponseDto(
                    training.Id.ToString(),
                    training.TypeId.ToString(),
                    training.Duration,
                    training.Calories,
                    training.Difficulty,
                    training.Tiredness,
                    training.Notes,
                    training.DateTime.ToString()
                    );
            }
            catch (Exception e)
            {
                return Result.Fail(new Error("Invalid argument")
                    .WithMetadata("code", 400))
                    .WithError(e.Message);
            }
        }

        public Result<List<TrainingType>> GetAllTypes()
        {
            try
            {
                var result = _trainingRepository.GetAllTypes();
                return result;
            }
            catch (Exception e)
            {
                return Result.Fail(new Error("Accessed resource not found.")
                    .WithMetadata("code", 404))
                    .WithError(e.Message);
            }
        }
    }
}
