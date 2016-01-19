using System.Data.Entity;
using MyDietManagerAbstract.Abstraction.UnitOfWork;
using MyDietManagerEntities;

namespace myDietManager.IMP.Entities.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
