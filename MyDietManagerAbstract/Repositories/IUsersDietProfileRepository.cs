using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDietManagerAbstract.Entities;

namespace MyDietManagerAbstract.Repositories
{
    public interface IUsersDietProfileRepository : IBaseRepository<IDietProfile>
    {
        bool UserHasDietProfile(int id);
        IEnumerable<string> GetProfileName(IDietProfile user);
        IDietProfile GetProfile(int id, string profileName);
    }
}
