using System;

using First.Prototype.Core.ValueObjects;

namespace First.Prototype.Access.Domain.ValueObjects
{
  public class AccessToken : ValueObject
  {
    public DateTime Created { get; }
    public DateTime Expiration { get; }
    public bool RedefinePassword { get; }
    public string Token { get; }

    public AccessToken(string token, bool redefinePassword, DateTime created, DateTime expiration)
    {
      Token = token;
      RedefinePassword = redefinePassword;
      Created = created;
      Expiration = expiration;
    }
  }
}