using System;
using System.Reflection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;

namespace First.Prototype.Core.Configurations
{
  public static class SwaggerConfig
  {
    public static void AddSwaggerConfiguration(this IServiceCollection services, string title, string version)
    {
      if(services == null) throw new ArgumentNullException(nameof(services));

      services.AddSwaggerGen(s =>
      {
        s.SwaggerDoc(version, new OpenApiInfo
        {
          Version = version,
          Title = $"First.Prototype.{title}.Api"
        });

        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "Input the JWT like: Bearer {your token}",
          Name = "Authorization",
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });

        s.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
          }
        });

        s.ExampleFilters();
      });

      services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
      if(app == null) throw new ArgumentNullException(nameof(app));

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
      });
    }
  }
}