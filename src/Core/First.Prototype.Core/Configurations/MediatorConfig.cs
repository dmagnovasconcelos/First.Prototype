using First.Prototype.Core.Mediators;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Core.Configurations
{
  public static class MediatorConfig
  {
    public static void AddMediatorConfig(this IServiceCollection services)
    {
      services.AddScoped<IMediator, Mediator>();
    }
  }
}