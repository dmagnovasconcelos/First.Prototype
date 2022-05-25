using System;

using First.Prototype.Administrator.Domain.Commands.Validations;
using First.Prototype.Administrator.Domain.Entities;

namespace First.Prototype.Administrator.Domain.Commands
{
  public class UpdateUserCommand : UserCommand
  {
    public UpdateUserCommand(Guid id
      , string email
      , string firstName
      , string lastName
      , string nickName
      , DateTime birthDate)
    {
      Id = id;
      Email = email;
      FirstName = firstName;
      LastName = lastName;
      NickName = nickName;
      BirthDate = birthDate;
    }

    public override bool IsValid()
    {
      ValidationResult = new UpdateUserCommandValidation().Validate(this);
      return ValidationResult.IsValid;
    }

    public void UpdateEntity(ref User user)
    {
      user.Email = Email;
      user.FirstName = FirstName;
      user.LastName = LastName;
      user.NickName = NickName;
      user.BirthDate = BirthDate;
    }
  }
}