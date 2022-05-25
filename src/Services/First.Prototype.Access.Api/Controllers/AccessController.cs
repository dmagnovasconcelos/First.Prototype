using System.Threading.Tasks;

using First.Prototype.Access.Application.Interfaces;
using First.Prototype.Access.Application.ViewModels;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Core.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.Prototype.Access.Api.Controllers
{
  [Route("/api/v1/[controller]")]
  [ApiController]
  public class AccessController : ApiController
  {
    private readonly IAccessAppService _service;

    public AccessController(IAccessAppService service)
    {
      _service = service;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AccessResponse), StatusCodes.Status202Accepted)]
    [ProducesResponseType(typeof(AccessResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AccessResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(AccessResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Authentication([FromBody] AccessViewModel viewModel)
    {
      if(!ModelState.IsValid)
        return CustomResponse(ModelState);

      return CustomResponse(await _service.Authenticate(viewModel));
    }
  }
}