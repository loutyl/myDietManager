using System.Data.Entity;
using System.Linq;
using myDietManager.Abstraction.UnitOfWork;

namespace myDietManager.IMP.Entities.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }

        public User FindUserByCredentials(string username, string password)
        {
            return this.DbSet.First(user => user.UserName == username && user.Password == password);
        }

    }
}
