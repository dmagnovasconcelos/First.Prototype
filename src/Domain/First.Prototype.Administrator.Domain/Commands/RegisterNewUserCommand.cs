using System;

using Bogus;

using First.Prototype.Administrator.Domain.Commands.Validations;
using First.Prototype.Core.Utilities;

namespace First.Prototype.Administrator.Domain.Commands
{
  public class RegisterNewUserCommand : UserCommand
  {
    public RegisterNewUserCommand(string email
    , bool active
    , string firstName
    , string lastName
    , string nickName
    , DateTime birthDate)
    {
      Id = Guid.NewGuid();
      Active = active;
      Email = email;
      FirstName = firstName;
      LastName = lastName;
      NickName = nickName;
      BirthDate = birthDate;
      RedefinePassword = true;
      ValidationToken = Guid.NewGuid();
      Password = new Faker().Internet.Password(8);
    }

    public override bool IsValid()
    {
      ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}