using System.Threading.Tasks;

using First.Prototype.Core.Commands;
using First.Prototype.Core.Response;

namespace First.Prototype.Core.Mediators
{
  public interface IMediator
  {
    Task<TResponse> SendCommand<TCommand, TResponse>(TCommand Command)
        where TCommand : ICommand
        where TResponse : IResponse;
  }
}