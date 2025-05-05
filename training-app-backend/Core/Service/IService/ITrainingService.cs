using FluentResults;
using TrainingApp.API.DTO;
using TrainingApp.Core.Model;

namespace TrainingApp.Core.Service.IService
{
    public interface ITrainingService
    {
        Result<CreateTrainingResponseDto> CreateTraining( CreateTrainingDto trainingDto);
        Result<List<TrainingType>> GetAllTypes();
        Result<List<StatsResponseDto>> GetStatsForMonth(MonthDto monthDto);
    }
}
