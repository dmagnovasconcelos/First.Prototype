using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using First.Prototype.Administrator.Application.Interfaces;
using First.Prototype.Administrator.Application.ViewModels;
using First.Prototype.Administrator.Domain.Commands;
using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Administrator.Domain.Responses;
using First.Prototype.Core.Mediators;

namespace First.Prototype.Administrator.Application.Services
{
  public class UserAppService : IUserAppService
  {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IUserQueryRepository _repository;

    public UserAppService(IMapper mapper
      , IMediator mediator
      , IUserQueryRepository repository)
    {
      _mapper = mapper;
      _mediator = mediator;
      _repository = repository;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
      return _mapper.Map<IEnumerable<UserViewModel>>(await _repository.GetAllAsync());
    }

    public async Task<UserViewModel> GetById(Guid id)
    {
      return _mapper.Map<UserViewModel>(await _repository.GetAsync(id));
    }

    public async Task<UserResponse> Register(UserViewModel viewModel)
    {
      var command = _mapper.Map<RegisterNewUserCommand>(viewModel);
      return await _mediator.SendCommand<RegisterNewUserCommand, UserResponse>(command);
    }

    public async Task<UserResponse> Remove(Guid id)
    {
      var command = new RemoveUserCommand(id);
      return await _mediator.SendCommand<RemoveUserCommand, UserResponse>(command);
    }

    public async Task<UserResponse> Update(UserViewModel viewModel)
    {
      var command = _mapper.Map<UpdateUserCommand>(viewModel);
      return await _mediator.SendCommand<UpdateUserCommand, UserResponse>(command);
    }
  }
}