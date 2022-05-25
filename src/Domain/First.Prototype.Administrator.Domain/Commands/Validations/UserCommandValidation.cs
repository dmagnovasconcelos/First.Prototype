using System;

using First.Prototype.Core.Commands.Validators;

using FluentValidation;

namespace First.Prototype.Administrator.Domain.Commands.Validations
{
  public abstract class UserCommandValidation : Validator<UserCommand>
  {
    protected static bool HaveMinimumAge(DateTime birthDate)
    {
      return birthDate <= DateTime.Now.AddYears(-16);
    }

    protected void ValidateBirthDate()
    {
      RuleFor(c => c.BirthDate)
          .NotEmpty()
          .Must(HaveMinimumAge)
          .WithMessage("The customer must have 16 years or more");
    }

    protected void ValidateEmail()
    {
      RuleFor(c => c.Email)
        .NotEmpty()
        .EmailAddress();
    }

    protected void ValidateId()
    {
      RuleFor(c => c.Id)
        .NotEqual(Guid.Empty);
    }

    protected void ValidateName()
    {
      RuleFor(x => x.FirstName)
        .NotNull()
        .NotEmpty()
        .Length(2, 50);

      RuleFor(x => x.LastName)
        .NotNull()
        .NotEmpty()
        .Length(2, 50);
    }
  }
}