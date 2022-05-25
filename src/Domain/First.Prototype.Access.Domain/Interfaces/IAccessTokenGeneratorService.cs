using First.Prototype.Access.Domain.ValueObjects;

namespace First.Prototype.Access.Domain.Interfaces
{
  public interface IAccessTokenGeneratorService<in T> where T : class
  {
    AccessToken GenerateAccessToken(T entity);

    AccessToken RefreshAccessToken(AccessToken accessToken);
  }
}