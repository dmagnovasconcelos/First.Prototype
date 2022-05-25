using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using First.Prototype.Administrator.Application.Interfaces;
using First.Prototype.Administrator.Application.ViewModels;
using First.Prototype.Administrator.Domain.Responses;
using First.Prototype.Core.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.Prototype.Administrator.Api.Controllers
{
  [Route("/api/v1/[controller]")]
  [ApiController]
  [Authorize]
  public class UserController : ApiController
  {
    private readonly IUserAppService _service;

    public UserController(IUserAppService service)
    {
      _service = service;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
      return CustomResponse(await _service.Remove(id));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
      return CustomResponse(await _service.GetById(id));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
      return CustomResponse(await _service.GetAll());
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] UserViewModel viewModel)
    {
      if(!ModelState.IsValid)
        return CustomResponse(ModelState);

      return CustomResponse(await _service.Register(viewModel));
    }

    [HttpPut]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] UserViewModel viewModel)
    {
      if(!ModelState.IsValid)
        return CustomResponse(ModelState);

      return CustomResponse(await _service.Update(viewModel));
    }
  }
}