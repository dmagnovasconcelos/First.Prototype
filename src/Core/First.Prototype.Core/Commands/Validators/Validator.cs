using System.Collections.Generic;
using System.Linq;

using FluentValidation;

namespace First.Prototype.Core.Commands.Validators
{
  public abstract class Validator<TCommand> : AbstractValidator<TCommand>, IValidator<TCommand>
    where TCommand : ICommand
  {
    private readonly List<KeyValuePair<string, string>> _errors = new();

    private bool _isValid;

    public IReadOnlyCollection<KeyValuePair<string, string>> Errors => _errors.ToArray();

    public bool IsValid => _isValid;

    protected Validator()
    { }

    bool IValidator<TCommand>.Validate(TCommand command)
    {
      var result = Validate(command);
      _isValid = result.IsValid;

      _errors.Clear();
      _errors.AddRange(result.Errors
        .Select(e => new KeyValuePair<string, string>(e.ErrorCode, e.ErrorMessage)));

      return result.IsValid;
    }
  }
}