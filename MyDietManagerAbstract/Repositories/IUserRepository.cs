using MyDietManagerAbstract.Entities;

namespace MyDietManagerAbstract.Repositories
{
    public interface IUserRepository : IBaseRepository<IUser>
    {
        IUser FindUserByCredentials(string username, string password);
    }
}
