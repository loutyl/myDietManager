﻿using System;
using System.Collections.Generic;

namespace MyDietManagerAbstract.Abstraction.Repositories
{
    public interface IRepository<T> : IRepository
    {
        T Get(Func<T, bool> predicate);
        T Single(object primaryKey);
        int Insert(T entity);
        void InsertWithoutSaving(T entity);
        void Delete(T entity);
        void Update(T entity);
        bool Exists(object primaryKey);
        IEnumerable<T> GetAll();
    }
}
