using System;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace First.Prototype.Core.Configurations
{
  public static class AuthenticationConfig
  {
    public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<AuthenticationOptions>(configuration.GetSection("AuthenticationConfig"));

      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("AuthenticationConfig:SecurityKey")));
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = signingKey,
          ValidateIssuer = true,
          ValidIssuer = configuration.GetValue<string>("AuthenticationConfig:Issuer"),
          ValidateAudience = true,
          ValidAudience = configuration.GetValue<string>("AuthenticationConfig:Audience"),
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          RequireExpirationTime = true
        };
      });
    }
  }
}