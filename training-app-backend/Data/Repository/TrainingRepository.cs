using Microsoft.EntityFrameworkCore;
using TrainingApp.API.DTO;
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

        public List<Training> GetAllBetweenDates(DateTime startDateTime, Guid userId)
        {
            return _dbContext.Trainings
                    .Where(x => x.DateTime >= startDateTime && x.DateTime < startDateTime.AddMonths(1) && x.UserId.Equals(userId))
                    .ToList();
        }

        public Training Create(Training training)
        {
            _dbContext.Trainings.Add(training);
            _dbContext.SaveChanges();
            return training;
        }
    }
}
