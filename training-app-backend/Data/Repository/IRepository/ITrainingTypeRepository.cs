using TrainingApp.Core.Model;

namespace TrainingApp.Data.Repository.IRepository
{
    public interface ITrainingTypeRepository
    {
        List<TrainingType> GetAllTypes();
    }
}
