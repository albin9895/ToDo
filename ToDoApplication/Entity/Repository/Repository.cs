
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoApplication.Entity;

namespace ToDoApplication.Entities.Repository
{
    /// <summary>
    /// Generic repository implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ToDoDbContext _dbContext;
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Create(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }
      
        public void DeleteBy(Expression<Func<T, bool>> predicate)
        {
            var entity = dbSet.Where(predicate);
            if (entity.FirstOrDefault() != null)
            {
                dbSet.Remove(entity.FirstOrDefault());
            }
        }
     
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            if (predicate.Parameters.Any(x => x.Name != "f"))
            {
                return dbSet.Where(predicate);
            }
            else
            {
                return dbSet.AsQueryable<T>();
            }
        }
        public virtual IQueryable<T> GetAll()
        {

            return dbSet;
            
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
       
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

       
    }
}
