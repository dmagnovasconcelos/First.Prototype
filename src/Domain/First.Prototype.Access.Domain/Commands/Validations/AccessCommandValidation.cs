using First.Prototype.Core.Commands.Validators;

using FluentValidation;

namespace First.Prototype.Access.Domain.Commands.Validations
{
  public class AccessCommandValidation : Validator<AccessCommand>
  {
    public AccessCommandValidation()
    {
      const string email = "E-mail";
      const string password = "Password";

      RuleFor(x => x.Email)
        .NotNull().WithName(email)
        .NotEmpty().WithName(email)
        .EmailAddress().WithName(email);

      RuleFor(x => x.Password)
        .NotNull().WithName(password)
        .NotEmpty().WithName(password)
        .Length(8, 20).WithName(password);
    }
  }
}