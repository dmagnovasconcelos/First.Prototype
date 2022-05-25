namespace First.Prototype.Core.Response
{
  public enum TypeOfResponseFailure
  {
    Null,
    InvalidCommand,
    NotAuthorized,
    Error,
    NotFound
  }

  public enum TypeOfResponseSuccess
  {
    Null,
    Success,
    Created,
    Accepted,
    NoContent
  }
}