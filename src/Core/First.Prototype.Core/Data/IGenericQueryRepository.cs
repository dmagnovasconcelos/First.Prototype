using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using First.Prototype.Core.Entities;

namespace First.Prototype.Core.Data
{
  public interface IGenericQueryRepository<T> where T : Entity
  {
    Task DeleteOneAsync(T entity);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetAsync(Expression<Func<T, bool>> filter);

    Task<T> GetAsync(Guid id);

    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter);

    Task InsertOneAsyn(T entity);

    Task ReplaceOneAsync(T entity);
  }
}