using System;

using First.Prototype.Core.Entities;

namespace First.Prototype.Administrator.Domain.Entities
{
  public class User : Entity
  {
    public bool Active { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string Password { get; set; }
    public bool RedefinePassword { get; set; }
    public Guid? ValidationToken { get; set; }

    public User()
    {
      Id = Guid.NewGuid();
      Active = true;
    }

    public User(Guid id
      , bool active
      , string email
      , string firstName
      , string lastName
      , string nickName
      , string password
      , bool redefinePassword
      , Guid? validationToken
      , DateTime birthDate)
    {
      Id = id;
      Active = active;
      Email = email;
      FirstName = firstName;
      LastName = lastName;
      NickName = nickName;
      Password = password;
      RedefinePassword = redefinePassword;
      ValidationToken = validationToken;
      BirthDate = birthDate;
    }
  }
}