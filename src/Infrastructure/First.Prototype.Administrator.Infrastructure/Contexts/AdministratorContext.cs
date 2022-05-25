using First.Prototype.Administrator.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore;

namespace First.Prototype.Administrator.Infrastructure.Contexts
{
  public class AdministratorContext : DbContext
  {
    public AdministratorContext(DbContextOptions<AdministratorContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "pt_BR.UTF-8");

      modelBuilder.ApplyConfiguration(new UserMap());
    }
  }
}