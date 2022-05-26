using Bogus;

using ExpectedObjects;

using First.Prototype.Access.Domain.Commands;

using Xunit;

namespace First.Prototype.Access.Tests.Domain.Command
{
  public class AccessCommandTest
  {
    private readonly Faker _faker;

    public AccessCommandTest()
    {
      _faker = new Faker();
    }

    [Theory]
    [InlineData(nameof(AccessCommand))]
    [InlineData(null)]
    public void InvalidCommand_Email(string email)
    {
      var command = new AccessCommand(email, _faker.Internet.Password());
      Assert.NotNull(command);
      Assert.False(command.IsValid());
    }

    [Theory]
    [InlineData(6)]
    [InlineData(null)]
    public void InvalidCommand_Password(int? count)
    {
      var password = count is null ? string.Empty : _faker.Internet.Password(count.Value);
      var command = new AccessCommand(_faker.Internet.Email(), password);
      Assert.NotNull(command);
      Assert.False(command.IsValid());
    }

    [Fact]
    public void MustCreateCommand()
    {
      var expectedCommand = new
      {
        Email = _faker.Internet.Email(),
        Password = _faker.Internet.Password(8)
      };

      var command = new AccessCommand(expectedCommand.Email, expectedCommand.Password);
      Assert.NotNull(command);
      Assert.True(command.IsValid());
      expectedCommand.ToExpectedObject().ShouldMatch(command);
    }
  }
}