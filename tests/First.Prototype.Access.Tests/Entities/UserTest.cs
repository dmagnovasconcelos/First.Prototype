using Bogus;

using ExpectedObjects;

using First.Prototype.Access.Domain.Entities;

using Xunit;

namespace First.Prototype.Access.Tests.Entities
{
  public class UserTest
  {
    [Fact]
    public void MustCreateUser()
    {
      var faker = new Faker();
      var expectedUser = new
      {
        Id = faker.Random.Guid(),
        Password = faker.Internet.Password(8),
        Email = faker.Internet.Email(),
        Active = faker.Random.Bool(),
        RedefinePassword = faker.Random.Bool(),
        ValidationToken = faker.Random.Guid()
      };

      User user = new(expectedUser.Id
          , expectedUser.Password
          , expectedUser.Email
          , expectedUser.Active
          , expectedUser.RedefinePassword
          , expectedUser.ValidationToken);

      Assert.NotNull(user);
      expectedUser.ToExpectedObject().ShouldMatch(user);
    }
  }
}