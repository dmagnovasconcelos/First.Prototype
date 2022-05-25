using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Administrator.Infrastructure.Contexts;
using First.Prototype.Core.Data;

namespace First.Prototype.Administrator.Infrastructure.Repositories
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    public UserRepository(AdministratorContext context)
        : base(context) { }
  }
}