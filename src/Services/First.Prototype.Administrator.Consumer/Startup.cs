using First.Prototype.Administrator.Consumer.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Administrator.Consumer
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
          {
            await context.Response.WriteAsync("First Prototype Administrator Consumer...");
          });
      });
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMassTransitBusConfig(Configuration);
      services.AddEmailConfig(Configuration);
      services.AddControllers();
    }
  }
}