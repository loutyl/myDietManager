using System.Data.Entity;
using myDietManager.Abstraction.UnitOfWork;

namespace myDietManager.IMP.Entities.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
