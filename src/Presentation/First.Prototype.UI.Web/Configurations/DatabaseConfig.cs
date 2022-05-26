using System;

using First.Prototype.Administrator.Infrastructure.Contexts;
using First.Prototype.Core.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.UI.Web.Configurations
{
  public static class DatabaseConfig
  {
    public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
      if(services == null) throw new ArgumentNullException(nameof(services));

      services.Configure<QueryDbOptions>(configuration.GetSection("QyerDbConnection"));

      services.AddDbContext<AdministratorContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<AdministratorContext>();
    }
  }
}