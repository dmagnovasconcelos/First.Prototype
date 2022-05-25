using System.Threading.Tasks;

using First.Prototype.Core.Commands;
using First.Prototype.Core.Response;

namespace First.Prototype.Core.Requests
{
  public interface IRequestHandler<TCommand, TResponse> : IBaseRequest
        where TCommand : ICommand
        where TResponse : IResponse
  {
    Task<TResponse> Handle(TCommand command);
  }
}