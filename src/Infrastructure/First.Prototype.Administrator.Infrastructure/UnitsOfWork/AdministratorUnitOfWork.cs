using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Administrator.Infrastructure.Contexts;
using First.Prototype.Core.Data;

namespace First.Prototype.Administrator.Infrastructure.UnitsOfWork
{
  public class AdministratorUnitOfWork : UnitOfWork<AdministratorContext>, IAdministratorUnitOfWork
  {
    public AdministratorUnitOfWork(AdministratorContext context)
        : base(context) { }
  }
}