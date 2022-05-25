using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Domain.ValueObjects;
using First.Prototype.Core.Configurations;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace First.Prototype.Access.Infrastructure.Services
{
  public class AccessTokenGeneratorService : IAccessTokenGeneratorService<User>
  {
    private readonly AuthenticationOptions _configuration;

    public AccessTokenGeneratorService(IOptions<AuthenticationOptions> configuration)
    {
      _configuration = configuration.Value;
    }

    public AccessToken GenerateAccessToken(User entity)
    {
      ClaimsIdentity identity = new(
          new GenericIdentity(entity.Email, "E-mail"),
          new[] {
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                  new Claim(JwtRegisteredClaimNames.UniqueName, entity.Email)
          }
      );

      var created = DateTime.Now;
      var expiration = created.AddMinutes(_configuration.Expiration);
      SecurityTokenDescriptor tokenDescriptor = new()
      {
        Issuer = _configuration.Issuer,
        Audience = _configuration.Audience,
        NotBefore = created,
        Expires = expiration,
        SigningCredentials = _configuration.SigningCredentials,
        Subject = identity
      };

      JwtSecurityTokenHandler tokenHandler = new();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var accessToken = tokenHandler.WriteToken(token);
      return new AccessToken(accessToken
        , entity.RedefinePassword
        , created
        , expiration);
    }

    //TODO: To implement
    public AccessToken RefreshAccessToken(AccessToken accessToken)
    {
      throw new NotImplementedException();
    }
  }
}