using AutoMapper;

using First.Prototype.Administrator.Application.ViewModels;
using First.Prototype.Administrator.Domain.Commands;

namespace First.Prototype.Administrator.Application.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public ViewModelToDomainMappingProfile()
    {
      CreateMap<UserViewModel, RegisterNewUserCommand>()
        .ConstructUsing(x => new RegisterNewUserCommand(x.Email
          , x.Active
          , x.FirstName
          , x.LastName
          , x.NickName
          , x.BirthDate
          ));

      CreateMap<UserViewModel, UpdateUserCommand>()
        .ConstructUsing(x => new UpdateUserCommand(x.Id
          , x.Email
          , x.FirstName
          , x.LastName
          , x.NickName
          , x.BirthDate
          ));
    }
  }
}