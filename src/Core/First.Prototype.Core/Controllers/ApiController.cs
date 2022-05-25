using System.Collections.Generic;
using System.Linq;
using System.Net;

using First.Prototype.Core.Interfaces;
using First.Prototype.Core.Response;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace First.Prototype.Core.Controllers
{
  [ApiController]
  public abstract class ApiController : ControllerBase
  {
    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
      var errors = modelState.Values.SelectMany(e => e.Errors).Select(x => x.ErrorMessage);

      return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
      {
          { "Messages", errors.ToArray() }
      }));
    }

    protected IActionResult CustomResponse(BaseResponse response)
    {
      if(!response.Success)
      {
        return response.ResponseFailure switch
        {
          TypeOfResponseFailure.Error => StatusCode((int)HttpStatusCode.InternalServerError, response),
          TypeOfResponseFailure.NotAuthorized => Unauthorized(),
          TypeOfResponseFailure.NotFound => NotFound(),
          _ => BadRequest(response)
        };
      }

      return response.ResponseSuccess switch
      {
        TypeOfResponseSuccess.Created => Created(string.Empty, response),
        TypeOfResponseSuccess.Accepted => Accepted(response),
        TypeOfResponseSuccess.NoContent => NoContent(),
        _ => Ok(response)
      };
    }

    protected IActionResult CustomResponse(IViewModel viewModel)
    {
      if(viewModel is null)
        return NotFound();

      return Ok(viewModel);
    }

    protected IActionResult CustomResponse(IEnumerable<IViewModel> viewsModel)
    {
      if(!viewsModel?.Any() ?? true)
        return NoContent();

      return Ok(viewsModel);
    }
  }
}