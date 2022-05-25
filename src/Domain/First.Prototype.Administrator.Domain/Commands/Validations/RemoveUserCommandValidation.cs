namespace First.Prototype.Administrator.Domain.Commands.Validations
{
  public class RemoveUserCommandValidation : UserCommandValidation
  {
    public RemoveUserCommandValidation()
    {
      ValidateId();
    }
  }
}