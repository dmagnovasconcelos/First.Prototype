using System;

using First.Prototype.Core.Entities;

namespace First.Prototype.Access.Domain.Entities
{
  public class User : Entity
  {
    public bool Active { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RedefinePassword { get; set; }
    public Guid? ValidationToken { get; set; }

    public User()
    { }

    public User(Guid id
        , string password
        , string email
        , bool active
        , bool redefinePassword
        , Guid? validationToken = null)
    {
      Id = id;
      Password = password;
      Email = email;
      Active = active;
      RedefinePassword = redefinePassword;
      ValidationToken = validationToken;
    }
  }
}