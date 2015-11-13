using MyDietManagerAbstract.Entities;
using MyDietManagerAbstract.Repositories;

namespace MyDietManagerAbstract.UnitOfWork
{
    public interface IUnitOfWork 
    {
        T GetRepository<T>();
        void Save();
    }
}
