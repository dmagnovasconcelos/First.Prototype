using System.Text;
using System.Text.Json.Serialization;

using FluentValidation.Results;

namespace First.Prototype.Core.Response
{
  public abstract class BaseResponse : IResponse
  {
    public string Message { get; }

    [JsonIgnore]
    public TypeOfResponseFailure ResponseFailure { get; }

    [JsonIgnore]
    public TypeOfResponseSuccess ResponseSuccess { get; }

    public object Result { get; init; }

    public bool Success { get; }

    protected BaseResponse(bool success
        , string message
        , TypeOfResponseSuccess responseSuccess)
    {
      Success = success;
      Message = message;
      ResponseSuccess = responseSuccess;
    }

    protected BaseResponse(bool success
        , string message
        , TypeOfResponseFailure responseFailure)
    {
      Success = success;
      Message = message;
      ResponseFailure = responseFailure;
    }
  }
}