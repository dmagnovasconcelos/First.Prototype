using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using First.Prototype.Administrator.Application.ViewModels;
using First.Prototype.Administrator.Domain.Responses;

namespace First.Prototype.Administrator.Application.Interfaces
{
  public interface IUserAppService
  {
    Task<IEnumerable<UserViewModel>> GetAll();

    Task<UserViewModel> GetById(Guid id);

    Task<UserResponse> Register(UserViewModel viewModel);

    Task<UserResponse> Remove(Guid id);

    Task<UserResponse> Update(UserViewModel viewModel);
  }
}