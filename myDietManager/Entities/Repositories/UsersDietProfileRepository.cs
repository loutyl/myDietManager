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

        public IEnumerable<string> GetDietProfileName(User user)
        {
            return this.DbSet.AsEnumerable().Where(entry => entry.UserID == user.UserID).Select(entry => entry.ProfileName.Trim());
        }
    }
}
