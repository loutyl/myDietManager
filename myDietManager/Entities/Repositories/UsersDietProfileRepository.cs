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
    }
}
