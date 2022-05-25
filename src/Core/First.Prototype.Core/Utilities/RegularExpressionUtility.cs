namespace First.Prototype.Core.Utilities
{
  public static class RegularExpressionUtility
  {
    public const string PasswordRegularExpression = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$";
  }
}