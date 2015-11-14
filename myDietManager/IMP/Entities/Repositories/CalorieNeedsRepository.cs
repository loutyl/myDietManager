using System.Data.Entity;
using myDietManager.Abstraction.UnitOfWork;

namespace myDietManager.IMP.Entities.Repositories
{
    public class CalorieNeedsRepository : BaseRepository<UserCalorieNeeds>
    {
        public CalorieNeedsRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
