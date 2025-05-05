using TrainingApp.Core.Model;
using TrainingApp.Data.Repository.IRepository;

namespace TrainingApp.Data.Repository
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly TrainingContext _dbContext;

        public TrainingTypeRepository(TrainingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TrainingType> GetAllTypes()
        {
            return _dbContext.TrainingTypes.ToList();
        }
    }
}
