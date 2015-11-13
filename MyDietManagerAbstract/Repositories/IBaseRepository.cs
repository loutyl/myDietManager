﻿using System.Collections.Generic;

namespace MyDietManagerAbstract.Repositories
{
    public interface IBaseRepository<T>
    {
        T Single(object primaryKey);
        int Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool Exists(object primaryKey);
        IEnumerable<T> GetAll();
    }
}
