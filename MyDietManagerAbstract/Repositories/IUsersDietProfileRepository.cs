using System.Collections.Generic;
using MyDietManagerAbstract.Entities;

namespace MyDietManagerAbstract.Repositories
{
    public interface IUsersDietProfileRepository : IBaseRepository<IDietProfile>
    {
        bool UserHasDietProfile(int id);
        IEnumerable<string> GetProfileName(IDietProfile user);
        IDietProfile GetProfile(int id, string profileName);
        void CompleteDietProfileCreation(IDietProfile dietProfile);
    }
}
