using TrainingApp.Core.Model;
using TrainingApp.Data.Repository.IRepository;

namespace TrainingApp.Data.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext _dbContext;

        public TrainingRepository(TrainingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TrainingType> GetAllTypes()
        {
            return _dbContext.TrainingTypes.ToList();
        }

        public Training Create(Training training)
        {
            _dbContext.Trainings.Add(training);
            _dbContext.SaveChanges();
            return training;
        }
    }
}
