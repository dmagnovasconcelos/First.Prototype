using System.Text;

using First.Prototype.Access.Domain.ValueObjects;
using First.Prototype.Core.Response;

using FluentValidation.Results;

namespace First.Prototype.Access.Domain.Responses
{
  public enum TypeOfResponseUnauthorized
  {
    Null,
    NotFound,
    InactiveUser,
    InvalidPassword
  }

  public static class ResponseUnauthorized
  {
    public static string GetString(this TypeOfResponseUnauthorized responseUnauthorized)
    {
      return responseUnauthorized switch
      {
        TypeOfResponseUnauthorized.NotFound => "User not found!",
        TypeOfResponseUnauthorized.InactiveUser => "Inactive user!",
        TypeOfResponseUnauthorized.InvalidPassword => "Invalid password",
        _ => "Unauthorized"
      };
    }
  }

  public class AccessResponse : BaseResponse
  {
    public AccessResponse(bool success, string message, TypeOfResponseSuccess responseSuccess)
      : base(success, message, responseSuccess) { }

    public AccessResponse(bool success, string message, TypeOfResponseFailure responseFailure)
      : base(success, message, responseFailure) { }

    public static AccessResponse Authorized(AccessToken accessToken)
    {
      return new(true, "Authorized", TypeOfResponseSuccess.Accepted)
      {
        Result = accessToken
      };
    }

    public static AccessResponse Error(string message)
    {
      return new(false, message, TypeOfResponseFailure.Error);
    }

    public static AccessResponse InvalidCommand(string message)
    {
      return new(false, message, TypeOfResponseFailure.InvalidCommand);
    }

    public static AccessResponse Unauthorized(TypeOfResponseUnauthorized responseUnauthorized)
    {
      return new(false, responseUnauthorized.GetString(), TypeOfResponseFailure.NotAuthorized);
    }
  }
}