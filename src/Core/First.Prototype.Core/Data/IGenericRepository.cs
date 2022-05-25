using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace First.Prototype.Core.Data
{
  public interface IGenericRepository<T> where T : class
  {
    void Add(T entity);

    Task AddAsync(T entity);

    Task AddRange(IEnumerable<T> entities);

    Task<T> Get(Expression<Func<T, bool>> filter);

    Task<IEnumerable<T>> GetAll();

    Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    void Update(T entity);
  }
}