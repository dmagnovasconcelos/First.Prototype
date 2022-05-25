using AutoMapper;

using First.Prototype.Administrator.Application.ViewModels;
using First.Prototype.Administrator.Domain.Entities;

namespace First.Prototype.Administrator.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<User, UserViewModel>()
        .ConstructUsing(x => new UserViewModel(x.Id
          , x.Active
          , x.Email
          , x.FirstName
          , x.LastName
          , x.NickName
          , x.BirthDate
          ));
    }
  }
}