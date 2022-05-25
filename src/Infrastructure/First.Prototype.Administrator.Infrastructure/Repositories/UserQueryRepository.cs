using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Core.Configurations;
using First.Prototype.Core.Data;

using Microsoft.Extensions.Options;

namespace First.Prototype.Administrator.Infrastructure.Repositories
{
  public class UserQueryRepository : GenericQueryRepository<User>, IUserQueryRepository
  {
    public UserQueryRepository(IOptions<QueryDbOptions> options)
      : base(options) { }
  }
}