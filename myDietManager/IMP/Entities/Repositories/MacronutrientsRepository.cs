using System.Data.Entity;
using myDietManager.Abstraction.UnitOfWork;

namespace myDietManager.IMP.Entities.Repositories
{
    public class MacronutrientsRepository : BaseRepository<UserMacronutrients>
    {
        public MacronutrientsRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
