namespace First.Prototype.Administrator.Domain.Commands.Validations
{
  public class RegisterNewUserCommandValidation : UserCommandValidation
  {
    public RegisterNewUserCommandValidation()
    {
      ValidateName();
      ValidateBirthDate();
      ValidateEmail();
    }
  }
}