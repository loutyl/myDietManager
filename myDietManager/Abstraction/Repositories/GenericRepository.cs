using System;
using System.Collections.Generic;
using myDietManager.Abstraction.UnitOfWork;

namespace myDietManager.Abstraction.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T>
    {
        protected GenericRepository(IUnitOfWork unitOfWork)
        {
            unitOfWork.Register(this);
        }

        public abstract T Get(Func<T, bool> predicate);
        public abstract T Single(object primaryKey);
        public abstract int Insert(T entity);
        public abstract void InsertWithoutSaving(T entity);
        public abstract void Delete(T entity);
        public abstract void Update(T entity);
        public abstract bool Exists(object primaryKey);
        public abstract IEnumerable<T> GetAll();
        public abstract void Save();
    }
}
