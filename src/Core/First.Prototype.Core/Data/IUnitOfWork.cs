using System.Threading.Tasks;

namespace First.Prototype.Core.Data
{
  public interface IUnitOfWork
  {
    Task<bool> Commit();
  }
}