using GreenPipes;
using First.Prototype.Administrator.Consumer.Consumers;
using First.Prototype.Core.Configurations;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Administrator.Consumer.Configurations
{
  public static class MassTransitBusConfig
  {
    public static void AddMassTransitBusConfig(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddMassTransit(x =>
      {
        x.AddConsumer<UserConsumer>();

        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
        {
          config.UseHealthCheck(provider);
          config.Host(configuration.GetValue<string>("BusOptions:Host"), h =>
          {
            h.Username(configuration.GetValue<string>("BusOptions:Username"));
            h.Password(configuration.GetValue<string>("BusOptions:Password"));
          });

          config.ReceiveEndpoint(configuration.GetValue<string>("BusOptions:ReceiveEndpoint"), ep =>
          {
            ep.PrefetchCount = 10;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<UserConsumer>(provider);
          });
        }));
      });

      services.AddMassTransitHostedService();
    }
  }
}