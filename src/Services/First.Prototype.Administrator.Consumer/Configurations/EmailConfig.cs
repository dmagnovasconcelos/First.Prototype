using First.Prototype.Administrator.Application.Services;
using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Core.Configurations;
using First.Prototype.Core.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Administrator.Consumer.Configurations
{
  public static class EmailConfig
  {
    public static void AddEmailConfig(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
      services.AddTransient<ISendEmail<User>, SendUserEmail>();
    }
  }
}