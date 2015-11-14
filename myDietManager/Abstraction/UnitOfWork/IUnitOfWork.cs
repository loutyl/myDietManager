using myDietManager.Abstraction.Repositories;

namespace myDietManager.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Register(IRepository repository);
        void Save();
    }
}
