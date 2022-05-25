using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using First.Prototype.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace First.Prototype.Core.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : Entity
  {
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
      _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
      _dbSet.Add(entity);
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
      _dbSet.AddRange(entities);
    }

    Task IGenericRepository<T>.AddRange(IEnumerable<T> entities)
    {
      throw new NotImplementedException();
    }

    public async Task<T> Get(Expression<Func<T, bool>> filter)
    {
      return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter)
    {
      return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
    }

    public void Remove(T entity)
    {
      _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
      _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
      _dbSet.Update(entity);
    }
  }
}