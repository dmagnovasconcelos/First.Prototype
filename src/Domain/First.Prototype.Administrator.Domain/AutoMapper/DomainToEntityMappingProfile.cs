using AutoMapper;

using First.Prototype.Administrator.Domain.Commands;
using First.Prototype.Administrator.Domain.Entities;

namespace First.Prototype.Administrator.Domain.AutoMapper
{
  public class DomainToEntityMappingProfile : Profile
  {
    public DomainToEntityMappingProfile()
    {
      CreateMap<UserCommand, User>()
      .ConstructUsing(x => new User(x.Id
        , x.Active
        , x.Email
        , x.FirstName
        , x.LastName
        , x.NickName
        , x.Password
        , x.RedefinePassword
        , x.ValidationToken
        , x.BirthDate
      ));
    }
  }
}