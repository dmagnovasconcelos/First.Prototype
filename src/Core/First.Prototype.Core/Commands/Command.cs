using System.Text;

using FluentValidation.Results;

namespace First.Prototype.Core.Commands
{
  public abstract class Command : ICommand
  {
    public ValidationResult ValidationResult { get; set; }

    protected Command()
    {
      ValidationResult = new ValidationResult();
    }

    public virtual bool IsValid()
    {
      return ValidationResult.IsValid;
    }

    public virtual string ToErrorMessage()
    {
      var message = new StringBuilder();
      foreach(var error in ValidationResult.Errors)
        message.Append($"{error.ErrorMessage}\r\n");

      return message.ToString();
    }
  }
}