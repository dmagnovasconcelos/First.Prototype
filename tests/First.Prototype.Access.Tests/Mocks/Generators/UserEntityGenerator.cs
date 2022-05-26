using System;
using System.Collections.Generic;
using System.Linq;

using Bogus;

using First.Prototype.Access.Domain.Entities;

namespace First.Prototype.Access.Tests.Mocks.Generators
{
  public static class UserEntityGenerator
  {
    public static List<User> RandomGenerator(int count)
    {
      return Enumerable.Range(1, count).Select(_ => RandomGenerator()).ToList();
    }

    public static User RandomGenerator()
    {
      return new Faker<User>()
            .CustomInstantiator(f => new User())
            .StrictMode(false)
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Active, f => f.Random.Bool())
            .RuleFor(e => e.Email, f => f.Internet.Email())
            .RuleFor(e => e.Password, f => f.Internet.Password(8));
    }
  }
}