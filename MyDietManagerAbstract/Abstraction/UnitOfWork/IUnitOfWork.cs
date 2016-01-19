using MyDietManagerAbstract.Abstraction.Repositories;

namespace MyDietManagerAbstract.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Register(IRepository repository);
        void Save();
    }
}
