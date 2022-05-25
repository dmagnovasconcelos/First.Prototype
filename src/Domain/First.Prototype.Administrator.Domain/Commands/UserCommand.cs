using System;

using First.Prototype.Core.Commands;

namespace First.Prototype.Administrator.Domain.Commands
{
  public abstract class UserCommand : Command
  {
    public bool Active { get; protected set; }
    public DateTime BirthDate { get; protected set; }
    public string Email { get; protected set; }
    public string FirstName { get; protected set; }
    public Guid Id { get; protected set; }
    public string LastName { get; protected set; }
    public string NickName { get; protected set; }
    public string Password { get; protected set; }
    public bool RedefinePassword { get; protected set; }
    public Guid? ValidationToken { get; protected set; }
  }
}