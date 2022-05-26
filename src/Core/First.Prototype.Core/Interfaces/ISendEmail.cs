using System.Threading.Tasks;

using First.Prototype.Core.Entities;

namespace First.Prototype.Core.Interfaces
{
  public interface ISendEmail<in T> where T : Entity
  {
    Task SendEmailAsync(T entity);
  }
}