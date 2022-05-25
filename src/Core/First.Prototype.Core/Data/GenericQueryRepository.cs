using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using First.Prototype.Core.Configurations;
using First.Prototype.Core.Entities;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace First.Prototype.Core.Data
{
  public class GenericQueryRepository<T> : IGenericQueryRepository<T> where T : Entity
  {
    protected readonly IMongoCollection<T> _mongoCollection;

    public GenericQueryRepository(IOptions<QueryDbOptions> options)
    {
      var mongoClient = new MongoClient(options.Value.ConnectionString);
      var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
      _mongoCollection = mongoDatabase.GetCollection<T>(nameof(T));
    }

    public async Task DeleteOneAsync(T entity)
    {
      await _mongoCollection.DeleteOneAsync(x => x.Id == entity.Id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _mongoCollection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
      return await _mongoCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
      return await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter)
    {
      return await _mongoCollection.Find(filter).ToListAsync();
    }

    public async Task InsertOneAsyn(T entity)
    {
      await _mongoCollection.InsertOneAsync(entity);
    }

    public async Task ReplaceOneAsync(T entity)
    {
      await _mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }
  }
}