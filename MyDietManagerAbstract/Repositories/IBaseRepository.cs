using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
