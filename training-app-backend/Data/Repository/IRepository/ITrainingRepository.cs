using TrainingApp.Core.Model;

namespace TrainingApp.Data.Repository.IRepository
{
    public interface ITrainingRepository
    {
        Training Create(Training training);
        List<TrainingType> GetAllTypes();
    }
}
