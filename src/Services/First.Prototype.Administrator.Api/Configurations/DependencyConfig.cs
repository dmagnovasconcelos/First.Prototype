using First.Prototype.Administrator.Application.Interfaces;
using First.Prototype.Administrator.Application.Services;
using First.Prototype.Administrator.Domain.Commands;
using First.Prototype.Administrator.Domain.Handlers;
using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Administrator.Domain.Responses;
using First.Prototype.Administrator.Infrastructure.Repositories;
using First.Prototype.Administrator.Infrastructure.UnitsOfWork;
using First.Prototype.Core.Requests;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Administrator.Api.Configurations
{
  public static class DependencyConfig
  {
    public static void AddDependencyConfig(this IServiceCollection services)
    {
      // Application
      services.AddScoped<IUserAppService, UserAppService>();

      // Repository
      services
        .AddScoped<IUserQueryRepository, UserQueryRepository>()
        .AddScoped<IUserRepository, UserRepository>();

      // UnitOfWork
      services.AddScoped<IAdministratorUnitOfWork, AdministratorUnitOfWork>();

      // Commands
      services
        .AddTransient<IRequestHandler<RegisterNewUserCommand, UserResponse>, UserHandler>()
        .AddTransient<IRequestHandler<UpdateUserCommand, UserResponse>, UserHandler>()
        .AddTransient<IRequestHandler<RemoveUserCommand, UserResponse>, UserHandler>();
    }
  }
}