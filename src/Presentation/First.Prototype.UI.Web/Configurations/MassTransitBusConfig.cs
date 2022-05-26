using System;

using First.Prototype.Core.Configurations;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.UI.Web.Configurations
{
  public static class MassTransitBusConfig
  {
    public static void AddMassTransitBusConfig(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<BusOptions>(configuration.GetSection("BusOptions"));
      services.AddMassTransit(x =>
      {
        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
        {
          config.UseHealthCheck(provider);
          config.Host(new Uri(configuration.GetValue<string>("BusOptions:Host")), h =>
          {
            h.Username(configuration.GetValue<string>("BusOptions:Username"));
            h.Password(configuration.GetValue<string>("BusOptions:Password"));
          });
        }));
      });

      services.AddMassTransitHostedService();
    }
  }
}