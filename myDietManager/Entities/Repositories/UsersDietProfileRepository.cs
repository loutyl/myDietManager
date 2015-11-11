using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
    public class UsersDietProfileRepository : BaseRepository<UsersDietProfile>
    {
        public UsersDietProfileRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }

        public bool UserHasDietProfile(int userID)
        {
            return this.DbSet.AsEnumerable().Any(entry => entry.UserID == userID);
        }

        public IEnumerable<string> GetDietProfileName(User user)
        {
            return this.DbSet.AsEnumerable().Where(entry => entry.UserID == user.UserID).Select(entry => entry.ProfileName.Trim());
        }

        public UsersDietProfile GetDietProfile(int userID, string profileName)
        {
            return this.DbSet.AsEnumerable().First(entry => entry.UserID == userID && entry.ProfileName.Trim() == profileName);
        }
    }
}
