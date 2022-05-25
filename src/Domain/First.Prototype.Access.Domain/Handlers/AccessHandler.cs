using System;
using System.Threading.Tasks;

using First.Prototype.Access.Domain.Commands;
using First.Prototype.Access.Domain.Entities;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Core.Requests;

namespace First.Prototype.Access.Domain.Handlers
{
  public class AccessHandler : IRequestHandler<AccessCommand, AccessResponse>
  {
    private readonly IAccessTokenGeneratorService<User> _tokenGeneratorService;
    private readonly IUserRepository _userRepository;

    public AccessHandler(IUserRepository userRepository
      , IAccessTokenGeneratorService<User> tokenGeneratorService)
    {
      _userRepository = userRepository;
      _tokenGeneratorService = tokenGeneratorService;
    }

    public async Task<AccessResponse> Handle(AccessCommand command)
    {
      try
      {
        if(!command.IsValid())
          return AccessResponse.InvalidCommand(command.ToErrorMessage());

        var user = await _userRepository.Get(x => x.Email.Equals(command.Email));
        if(user is null)
          return AccessResponse.Unauthorized(TypeOfResponseUnauthorized.NotFound);

        if(!user.Active)
          return AccessResponse.Unauthorized(TypeOfResponseUnauthorized.InactiveUser);

        //TODO: Encrypt password
        if(!user.Password.Equals(command.Password))
          return AccessResponse.Unauthorized(TypeOfResponseUnauthorized.InvalidPassword);

        var accessToken = _tokenGeneratorService.GenerateAccessToken(user);
        return AccessResponse.Authorized(accessToken);
      }
      catch(Exception ex)
      {
        //TODO: Create log record
        return AccessResponse.Error(ex.Message);
      }
    }
  }
}