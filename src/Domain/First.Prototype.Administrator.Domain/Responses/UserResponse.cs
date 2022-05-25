using System;

using First.Prototype.Core.Response;

namespace First.Prototype.Administrator.Domain.Responses
{
  public enum TypeOfUserResponse
  {
    RegisterNew,
    Update,
    Remove
  }

  public static class ResponseUnauthorized
  {
    public static string GetString(this TypeOfUserResponse responseUnauthorized)
    {
      return responseUnauthorized switch
      {
        TypeOfUserResponse.RegisterNew => "New user registered successfully!",
        TypeOfUserResponse.Update => "User updated successfully!",
        TypeOfUserResponse.Remove => "User removed successfully!",
        _ => string.Empty
      };
    }

    public static TypeOfResponseSuccess GetTypeOfResponseSuccess(this TypeOfUserResponse responseUnauthorized)
    {
      return responseUnauthorized switch
      {
        TypeOfUserResponse.RegisterNew => TypeOfResponseSuccess.Created,
        TypeOfUserResponse.Update => TypeOfResponseSuccess.Accepted,
        TypeOfUserResponse.Remove => TypeOfResponseSuccess.Accepted,
        _ => TypeOfResponseSuccess.Null
      };
    }
  }

  public class UserResponse : BaseResponse
  {
    public UserResponse(bool success, string message, TypeOfResponseSuccess responseSuccess)
      : base(success, message, responseSuccess) { }

    public UserResponse(bool success, string message, TypeOfResponseFailure responseFailure)
      : base(success, message, responseFailure) { }

    public static UserResponse AlreadyExists()
    {
      return new(false, "User already exists", TypeOfResponseFailure.InvalidCommand);
    }

    public static UserResponse Error(string message)
    {
      return new(false, message, TypeOfResponseFailure.Error);
    }

    public static UserResponse InvalidCommand(string message)
    {
      return new(false, message, TypeOfResponseFailure.InvalidCommand);
    }

    public static UserResponse NotFound()
    {
      return new(false, "User not found", TypeOfResponseFailure.NotFound);
    }

    public static UserResponse Successfully(TypeOfUserResponse userResponse)
    {
      return new(true, userResponse.GetString(), userResponse.GetTypeOfResponseSuccess());
    }
  }
}