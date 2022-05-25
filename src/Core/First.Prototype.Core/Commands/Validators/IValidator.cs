using System.Collections.Generic;

namespace First.Prototype.Core.Commands.Validators
{
  public interface IValidator<TCommand> where TCommand : ICommand
  {
    IReadOnlyCollection<KeyValuePair<string, string>> Errors { get; }

    bool IsValid { get; }

    bool Validate(TCommand command);
  }
}