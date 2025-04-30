using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.Repository.IRepository;
using TrainingApp.Model;

namespace TrainingApp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainingContext _dbContext;

        public UserRepository(TrainingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault()
                ?? throw new KeyNotFoundException($"Not found: userId = {id}");
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users.Where(x => x.Email == email).FirstOrDefault()
                ?? throw new KeyNotFoundException($"Not found: email = {email}");
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

    }
}
