using System;

using First.Prototype.Administrator.Application.AutoMapper;
using First.Prototype.Administrator.Domain.AutoMapper;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Administrator.Api.Configurations
{
  public static class AutoMapperConfig
  {
    public static void AddAutoMapperConfig(this IServiceCollection services)
    {
      if(services == null) throw new ArgumentNullException(nameof(services));

      services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));
      services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
      services.AddAutoMapper(typeof(DomainToEntityMappingProfile));
    }
  }
}