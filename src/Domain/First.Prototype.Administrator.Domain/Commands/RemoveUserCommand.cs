using System;

using First.Prototype.Administrator.Domain.Commands.Validations;

namespace First.Prototype.Administrator.Domain.Commands
{
  public class RemoveUserCommand : UserCommand
  {
    public RemoveUserCommand(Guid id)
    {
      Id = id;
    }

    public override bool IsValid()
    {
      ValidationResult = new RemoveUserCommandValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}