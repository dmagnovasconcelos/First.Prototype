using First.Prototype.Access.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore;

namespace First.Prototype.Access.Infrastructure.Contexts
{
  public class AccessContext : DbContext
  {
    public AccessContext(DbContextOptions<AccessContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "pt_BR.UTF-8");

      modelBuilder.ApplyConfiguration(new UserMap());
    }
  }
}