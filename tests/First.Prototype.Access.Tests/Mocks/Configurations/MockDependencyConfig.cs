using First.Prototype.Access.Application.Interfaces;
using First.Prototype.Access.Domain.Commands;
using First.Prototype.Access.Domain.Commands.Validations;
using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Handlers;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Access.Infrastructure.Services;
using First.Prototype.Access.Tests.Mocks.Repositories;
using First.Prototype.Access.Tests.Mocks.Services;
using First.Prototype.Core.Commands.Validators;
using First.Prototype.Core.Requests;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Access.Tests.Mocks.Configurations
{
  public static class MockDependencyConfig
  {
    public static void AddMockDependencyConfig(this IServiceCollection services)
    {
      // Application
      services.AddScoped<IAccessAppService, MockAccessAppService>();

      // Repository
      services.AddScoped<IUserRepository, MockUserRepository>();

      // Commands
      services.AddTransient<IRequestHandler<AccessCommand, AccessResponse>, AccessHandler>();

      // Services
      services.AddTransient<IAccessTokenGeneratorService<User>, AccessTokenGeneratorService>();

      // Validators
      services.AddTransient<IValidator<AccessCommand>, AccessCommandValidation>();
    }
  }
}