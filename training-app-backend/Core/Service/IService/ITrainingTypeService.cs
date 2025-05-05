using FluentResults;
using TrainingApp.Core.Model;

namespace TrainingApp.Core.Service.IService
{
    public interface ITrainingTypeService
    {
        Result<List<TrainingType>> GetAllTypes();
    }
}
