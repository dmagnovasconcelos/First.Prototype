using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Infrastructure.Contexts;
using First.Prototype.Core.Data;

namespace First.Prototype.Access.Infrastructure.Repositories
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    public UserRepository(AccessContext context)
        : base(context) { }
  }
}