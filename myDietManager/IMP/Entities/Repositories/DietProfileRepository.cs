using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyDietManagerAbstract.Abstraction.Entities;
using MyDietManagerAbstract.Abstraction.UnitOfWork;
using MyDietManagerEntities;

namespace myDietManager.IMP.Entities.Repositories
{
    public class DietProfileRepository : BaseRepository<UsersDietProfile>
    {
        public DietProfileRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork, dbContext)
        {
        }

        public bool UserHasDietProfile(int id)
        {
            return this.DbSet.AsEnumerable().Any(entry => entry.UserID == id);
        }

        public IEnumerable<string> GetProfileName(User user)
        {
            return this.DbSet.AsEnumerable().Where(entry => entry.UserID == user.UserID).Select(entry => entry.ProfileName.Trim());
        }

        public UsersDietProfile GetProfile(int id, string profileName)
        {
            return this.DbSet.AsEnumerable().First(entry => entry.UserID == id && entry.ProfileName.Trim() == profileName);
        }

        public void CompleteDietProfileCreation(IDietProfile dietProfile)
        {
            
        }
    }
}
