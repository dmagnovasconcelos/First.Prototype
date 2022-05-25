using System.Threading.Tasks;

using First.Prototype.Access.Application.ViewModels;
using First.Prototype.Access.Domain.Responses;

namespace First.Prototype.Access.Application.Interfaces
{
  public interface IAccessAppService
  {
    Task<AccessResponse> Authenticate(AccessViewModel viewModel);
  }
}