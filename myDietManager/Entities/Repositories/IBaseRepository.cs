using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
     public interface IBaseRepository<in T>
     {
         int Insert(T entity);
         void Delete(T entity);
         bool Exists(object primaryKey);
     }
}
