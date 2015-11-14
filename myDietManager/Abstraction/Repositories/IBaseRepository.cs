using System.Collections.Generic;

namespace myDietManager.Abstraction.Repositories
{
    public interface IBaseRepository<T> : IRepository
    {
        T Single(object primaryKey);
        int Insert(T entity);
        void InsertWithoutSaving(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool Exists(object primaryKey);
        IEnumerable<T> GetAll();
    }
}
