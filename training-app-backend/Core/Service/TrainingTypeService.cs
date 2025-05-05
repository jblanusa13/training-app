using FluentResults;
using TrainingApp.Core.Model;
using TrainingApp.Core.Service.IService;
using TrainingApp.Data.Repository;
using TrainingApp.Data.Repository.IRepository;

namespace TrainingApp.Core.Service
{
    public class TrainingTypeService : ITrainingTypeService
    {
        private readonly ITrainingTypeRepository _trainingTypeRepository;
        public TrainingTypeService(ITrainingTypeRepository trainingTypeRepository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }

        public Result<List<TrainingType>> GetAllTypes()
        {
            try
            {
                var result = _trainingTypeRepository.GetAllTypes();
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
