using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
