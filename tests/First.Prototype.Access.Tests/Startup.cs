using System.IO;

using First.Prototype.Access.Api.Configurations;
using First.Prototype.Access.Tests.Mocks.Configurations;
using First.Prototype.Core.Configurations;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebMotions.Fake.Authentication.JwtBearer;

namespace First.Prototype.Access.Tests
{
  public sealed class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup()
    {
      var builder = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddUserSecrets<Startup>();

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMediatorConfig();
      services.AddAutoMapperConfig();
      services.AddAuthenticationConfig(Configuration);
      services.AddMockDependencyConfig();
      services.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddFakeJwtBearer();
    }
  }
}