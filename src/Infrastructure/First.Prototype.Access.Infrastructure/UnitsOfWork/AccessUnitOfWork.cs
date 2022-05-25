using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Infrastructure.Contexts;
using First.Prototype.Core.Data;

namespace First.Prototype.Access.Infrastructure.UnitsOfWork
{
  public class AccessUnitOfWork : UnitOfWork<AccessContext>, IAccessUnitOfWork
  {
    public AccessUnitOfWork(AccessContext context)
        : base(context) { }
  }
}