using System.Data.Entity;
using MyDietManagerAbstract.Abstraction.UnitOfWork;
using MyDietManagerEntities;

namespace myDietManager.IMP.Entities.Repositories
{
    public class CalorieNeedsRepository : BaseRepository<UserCalorieNeed>
    {
        public CalorieNeedsRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
