using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MyDietManagerDBEntities _dbEntities;
        internal DbSet<T> DbSet;

        public BaseRepository(MyDietManagerDBEntities dbEntities)
        {
            this._dbEntities = dbEntities;
            this.DbSet = dbEntities.Set<T>();
        }

        public T Single(object primaryKey)
        {
            return this.DbSet.Find(primaryKey);
        }

        public virtual int Insert(T entity)
        {
            dynamic obj = this.DbSet.Add(entity);
            this._dbEntities.SaveChanges();
            return obj.UserDietProfileID;
        }

        public virtual void InsertWithoutSaving(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if ( this._dbEntities.Entry(entity).State == EntityState.Detached )
            {
                this.DbSet.Attach(entity);
            }
            this.DbSet.Remove(entity);
            this._dbEntities.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            this.DbSet.Attach(entity);
            this._dbEntities.Entry(entity).State = EntityState.Modified;
            this._dbEntities.SaveChanges();
        }

        public virtual bool Exists(object primaryKey)
        {
            return this.DbSet.Find(primaryKey) != null;
        }

        public IEnumerable<T> GetAll()
        {
            return this.DbSet.AsEnumerable().ToList();
        }
    }
}
