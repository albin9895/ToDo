using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoApplication.Entities.Repository
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {       
        
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void DeleteBy(Expression<Func<T, bool>> predicate);
       
        T Create(T entity);      
       
        void Update(T entity);
        
        void Save();

       
       
      
    }
}
