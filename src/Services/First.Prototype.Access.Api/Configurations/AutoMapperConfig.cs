using System;

using First.Prototype.Access.Application.AutoMapper;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Access.Api.Configurations
{
  public static class AutoMapperConfig
  {
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
      if(services == null) throw new ArgumentNullException(nameof(services));

      services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));
    }
  }
}