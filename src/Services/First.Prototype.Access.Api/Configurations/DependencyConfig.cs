using First.Prototype.Access.Application.Interfaces;
using First.Prototype.Access.Application.Services;
using First.Prototype.Access.Domain.Commands;
using First.Prototype.Access.Domain.Commands.Validations;
using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Handlers;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Access.Infrastructure.Repositories;
using First.Prototype.Access.Infrastructure.Services;
using First.Prototype.Access.Infrastructure.UnitsOfWork;
using First.Prototype.Core.Commands.Validators;
using First.Prototype.Core.Requests;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Access.Api.Configurations
{
  public static class DependencyConfig
  {
    public static void AddDependencyConfig(this IServiceCollection services)
    {
      // Application
      services.AddScoped<IAccessAppService, AccessAppService>();

      // Repository
      services.AddScoped<IUserRepository, UserRepository>();

      // UnitOfWork
      services.AddScoped<IAccessUnitOfWork, AccessUnitOfWork>();

      // Commands
      services.AddTransient<IRequestHandler<AccessCommand, AccessResponse>, AccessHandler>();

      // Services
      services.AddTransient<IAccessTokenGeneratorService<User>, AccessTokenGeneratorService>();

      // Validators
      services.AddTransient<IValidator<AccessCommand>, AccessCommandValidation>();
    }
  }
}