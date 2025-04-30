using TrainingApp.Model;

namespace TrainingApp.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        User Create(User user);
    }
}
