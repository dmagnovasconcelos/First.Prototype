namespace First.Prototype.Administrator.Domain.Commands.Validations
{
  public class UpdateUserCommandValidation : UserCommandValidation
  {
    public UpdateUserCommandValidation()
    {
      ValidateId();
      ValidateName();
      ValidateBirthDate();
      ValidateEmail();
    }
  }
}