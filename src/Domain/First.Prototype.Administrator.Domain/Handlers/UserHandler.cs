using System;
using System.Threading.Tasks;

using AutoMapper;

using First.Prototype.Administrator.Domain.Commands;
using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Administrator.Domain.Interfaces;
using First.Prototype.Administrator.Domain.Responses;
using First.Prototype.Core.Requests;

namespace First.Prototype.Administrator.Domain.Handlers
{
  public class UserHandler : IRequestHandler<RegisterNewUserCommand, UserResponse>
    , IRequestHandler<UpdateUserCommand, UserResponse>
    , IRequestHandler<RemoveUserCommand, UserResponse>
  {
    private readonly IMapper _mapper;
    private readonly IUserQueryRepository _queryRepository;
    private readonly IUserRepository _repository;
    private readonly IAdministratorUnitOfWork _unitOfWork;

    public UserHandler(IUserRepository userRepository
      , IAdministratorUnitOfWork userUnitOfWork
      , IMapper mapper
      , IUserQueryRepository queryRepository)
    {
      _repository = userRepository;
      _unitOfWork = userUnitOfWork;
      _mapper = mapper;
      _queryRepository = queryRepository;
    }

    public async Task<UserResponse> Handle(RegisterNewUserCommand command)
    {
      try
      {
        if(!command.IsValid())
          return UserResponse.InvalidCommand(command.ToErrorMessage());

        if(await _repository.Get(x => x.Email.Equals(command.Email)) is not null)
          return UserResponse.AlreadyExists();

        var entity = _mapper.Map<User>(command);

        await _repository.AddAsync(entity);
        await _unitOfWork.Commit();
        await _queryRepository.InsertOneAsyn(entity).ConfigureAwait(false);
        return UserResponse.Successfully(TypeOfUserResponse.RegisterNew);
      }
      catch(Exception ex)
      {
        //TODO: Create log record
        return UserResponse.Error(ex.Message);
      }
    }

    public async Task<UserResponse> Handle(UpdateUserCommand command)
    {
      try
      {
        if(!command.IsValid())
          return UserResponse.InvalidCommand(command.ToErrorMessage());

        if(await _repository.Get(x => x.Email.Equals(command.Email) && x.Id != command.Id) is not null)
          return UserResponse.AlreadyExists();

        var entity = await _repository.Get(x => x.Id.Equals(command.Id));
        if(entity is null)
          return UserResponse.NotFound();

        command.UpdateEntity(ref entity);

        _repository.Update(entity);
        await _unitOfWork.Commit();
        await _queryRepository.ReplaceOneAsync(entity).ConfigureAwait(false);
        return UserResponse.Successfully(TypeOfUserResponse.Update);
      }
      catch(Exception ex)
      {
        //TODO: Create log record
        return UserResponse.Error(ex.Message);
      }
    }

    public async Task<UserResponse> Handle(RemoveUserCommand command)
    {
      try
      {
        if(!command.IsValid())
          return UserResponse.InvalidCommand(command.ToErrorMessage());

        var entity = await _repository.Get(x => x.Id.Equals(command.Id));
        if(entity is null)
          return UserResponse.NotFound();

        _repository.Remove(entity);
        await _unitOfWork.Commit();

        await _queryRepository.DeleteOneAsync(entity).ConfigureAwait(false);
        return UserResponse.Successfully(TypeOfUserResponse.Remove);
      }
      catch(Exception ex)
      {
        //TODO: Create log record
        return UserResponse.Error(ex.Message);
      }
    }
  }
}