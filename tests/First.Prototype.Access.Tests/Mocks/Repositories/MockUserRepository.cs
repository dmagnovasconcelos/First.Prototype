using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Tests.Mocks.Generators;

namespace First.Prototype.Access.Tests.Mocks.Repositories
{
  public class MockUserRepository : IUserRepository
  {
    private readonly List<User> _users;

    public MockUserRepository() => _users = UserEntityGenerator.RandomGenerator(20);

    public void Add(User entity)
    {
      _users.Add(entity);
    }

    public Task AddAsync(User entity)
    {
      _users.Add(entity);
      return Task.CompletedTask;
    }

    public Task AddRange(IEnumerable<User> entities)
    {
      _users.AddRange(entities);
      return Task.CompletedTask;
    }

    public Task<User> Get(Expression<Func<User, bool>> filter)
    {
      return Task.Run(() =>
          _users.AsQueryable().FirstOrDefault(filter)
      );
    }

    public Task<IEnumerable<User>> GetAll()
    {
      return Task.Run(() =>
          _users.AsEnumerable()
      );
    }

    public Task<IEnumerable<User>> GetList(Expression<Func<User, bool>> filter)
    {
      return Task.Run(() =>
          _users.AsQueryable().Where(filter).AsEnumerable()
      );
    }

    public void Remove(User entity)
    {
      _users.Remove(entity);
    }

    public void RemoveRange(IEnumerable<User> entities)
    {
      _users.RemoveAll(x => entities.Any(y => y == x));
    }

    public void Update(User entity)
    {
      _users.RemoveAll(x => x.Id == entity.Id);
      _users.Add(entity);
    }
  }
}