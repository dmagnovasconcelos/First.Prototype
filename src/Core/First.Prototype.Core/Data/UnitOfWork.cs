using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace First.Prototype.Core.Data
{
  public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
  {
    protected TContext Context { get; private set; }

    public UnitOfWork(TContext context)
    {
      Context = context;
    }

    public async Task<bool> Commit()
    {
      return await Context.SaveChangesAsync() > 0;
    }
  }
}