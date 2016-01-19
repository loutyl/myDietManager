using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MyDietManagerAbstract.Abstraction.Repositories;
using MyDietManagerAbstract.Abstraction.UnitOfWork;

namespace myDietManager.IMP.Entities.Repositories
{
    public class BaseRepository<T> : GenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        internal DbSet<T> DbSet;

        public BaseRepository(IUnitOfWork unitOfWork, DbContext dbContext) : base(unitOfWork)
        {
            this._dbContext = dbContext;
            this.DbSet = dbContext.Set<T>();
        }

        public override T Get(Func<T, bool> predicate)
        {
            return this.DbSet.First(predicate);
        }

        public override T Single(object primaryKey)
        {
            return this.DbSet.Find(primaryKey);
        }

        public override int Insert(T entity)
        {
            dynamic obj = this.DbSet.Add(entity);
            this._dbContext.SaveChanges();
            return obj.UserDietProfileID;
        }

        public override void InsertWithoutSaving(T entity)
        {
            this.DbSet.Add(entity);
        }

        public override void Delete(T entity)
        {
            if ( this._dbContext.Entry(entity).State == EntityState.Detached )
            {
                this.DbSet.Attach(entity);
            }
            this.DbSet.Remove(entity);
            this._dbContext.SaveChanges();
        }

        public override void Update(T entity)
        {
            this.DbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public override bool Exists(object primaryKey)
        {
            return this.DbSet.Find(primaryKey) != null;
        }

        public override IEnumerable<T> GetAll()
        {
            return this.DbSet.AsEnumerable().ToList();
        }

        public override void Save()
        {
            this._dbContext.SaveChanges();
        }
    }
}
