using First.Prototype.Access.Domain.Commands.Validations;
using First.Prototype.Core.Commands;

using FluentValidation.Results;

namespace First.Prototype.Access.Domain.Commands
{
  public class AccessCommand : Command
  {
    public string Email { get; }

    public string Password { get; }

    public AccessCommand(string email, string password)
    {
      Email = email;
      Password = password;
    }

    public override bool IsValid()
    {
      ValidationResult = new AccessCommandValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}