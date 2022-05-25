using System.Net;

using First.Prototype.Access.Api.Configurations;
using First.Prototype.Core.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace First.Prototype.Access.Api
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if(env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();
      app.UseRouting();

      app.UseCors(c =>
      {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
      });

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSwaggerSetup();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddHttpsRedirection(options =>
      {
        options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
        options.HttpsPort = 5050;
      });

      services.AddControllers();
      services.AddHttpClient();
      services.AddDatabaseConfiguration(Configuration);
      services.AddAuthenticationConfig(Configuration);
      services.AddSwaggerConfiguration("Access", "v1");
      services.AddAutoMapperConfiguration();
      services.AddMediatorConfig();
      services.AddDependencyConfig();
    }
  }
}