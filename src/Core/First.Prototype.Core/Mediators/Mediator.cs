using System;
using System.Threading.Tasks;

using First.Prototype.Core.Commands;
using First.Prototype.Core.Requests;
using First.Prototype.Core.Response;

using Microsoft.Extensions.DependencyInjection;

namespace First.Prototype.Core.Mediators
{
  public class Mediator : IMediator
  {
    private readonly IServiceProvider _container;

    public Mediator(IServiceProvider container)
    {
      _container = container;
    }

    public async Task<TResponse> SendCommand<TCommand, TResponse>(TCommand Command)
        where TCommand : ICommand
        where TResponse : IResponse
    {
      var handle = _container.GetService<IRequestHandler<TCommand, TResponse>>();
      return await handle.Handle(Command);
    }
  }
}