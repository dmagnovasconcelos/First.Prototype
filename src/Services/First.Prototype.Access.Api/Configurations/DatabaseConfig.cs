using System;

using First.Prototype.Access.Infrastructure.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Access.Api.Configurations
{
  public static class DatabaseConfig
  {
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      if(services == null) throw new ArgumentNullException(nameof(services));

      services.AddDbContext<AccessContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<AccessContext>();
    }
  }
}