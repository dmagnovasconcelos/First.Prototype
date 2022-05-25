using AutoMapper;

using First.Prototype.Access.Application.ViewModels;
using First.Prototype.Access.Domain.Commands;

namespace First.Prototype.Access.Application.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public ViewModelToDomainMappingProfile()
    {
      CreateMap<AccessViewModel, AccessCommand>()
        .ConstructUsing(x => new AccessCommand(x.Email, x.Password));
    }
  }
}