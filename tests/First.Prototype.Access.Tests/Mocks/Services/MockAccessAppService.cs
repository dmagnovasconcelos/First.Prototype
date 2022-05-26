using System.Threading.Tasks;

using AutoMapper;

using First.Prototype.Access.Application.Interfaces;
using First.Prototype.Access.Application.ViewModels;
using First.Prototype.Access.Domain.Commands;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Core.Mediators;

namespace First.Prototype.Access.Tests.Mocks.Services
{
  public class MockAccessAppService : IAccessAppService
  {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MockAccessAppService(IMapper mapper, IMediator mediator)
    {
      _mapper = mapper;
      _mediator = mediator;
    }

    public async Task<AccessResponse> Authenticate(AccessViewModel viewModel)
    {
      var accessCommand = _mapper.Map<AccessCommand>(viewModel);
      return await _mediator.SendCommand<AccessCommand, AccessResponse>(accessCommand);
    }
  }
}