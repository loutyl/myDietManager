using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
    public class UserCalorieNeedsRepository : BaseRepository<UserCalorieNeeds>
    {
        public UserCalorieNeedsRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
