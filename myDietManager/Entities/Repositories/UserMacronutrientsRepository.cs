using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
    public class UserMacronutrientsRepository : BaseRepository<UserMacronutrients>
    {
        public UserMacronutrientsRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
