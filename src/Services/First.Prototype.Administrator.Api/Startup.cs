using System.Net;

using First.Prototype.Administrator.Api.Configurations;
using First.Prototype.Core.Configurations;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace First.Prototype.Administrator.Api
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", true, true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      if(env.IsDevelopment())
      {
        builder.AddUserSecrets<Startup>();
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
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

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMediatR(typeof(Startup));
      services.AddHttpsRedirection(options =>
      {
        options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
        options.HttpsPort = 5052;
      });

      services.AddMassTransitBusConfig(Configuration);
      services.AddControllers();
      services.AddHttpClient();
      services.AddDatabaseConfig(Configuration);
      services.AddAuthenticationConfig(Configuration);
      services.AddSwaggerConfiguration("Administrator", "v1");
      services.AddAutoMapperConfig();
      services.AddMediatorConfig();
      services.AddDependencyConfig();
    }
  }
}