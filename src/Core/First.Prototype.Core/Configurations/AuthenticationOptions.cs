using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace First.Prototype.Core.Configurations
{
  public class AuthenticationOptions
  {
    public string Audience { get; set; }
    public int Expiration { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }

    public SigningCredentials SigningCredentials
    {
      get
      {
        return new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey))
            , SecurityAlgorithms.HmacSha256);
      }
    }
  }
}