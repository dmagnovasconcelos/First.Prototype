using System;
using System.Text;
using System.Threading.Tasks;

using Bogus;

using First.Prototype.Access.Api.Controllers;
using First.Prototype.Access.Application.Interfaces;
using First.Prototype.Access.Application.ViewModels;
using First.Prototype.Access.Domain.Interfaces;
using First.Prototype.Access.Domain.Responses;
using First.Prototype.Access.Domain.ValueObjects;
using First.Prototype.Core.Configurations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Xunit;

namespace First.Prototype.Access.Tests.Services.APIs
{
  public class AccessControllerTest
  {
    private readonly AccessController _controller;
    private readonly Faker _faker;
    private readonly AuthenticationOptions _options;
    private readonly IUserRepository _repository;

    public AccessControllerTest(IAccessAppService service
      , IUserRepository repository
      , IOptions<AuthenticationOptions> options)
    {
      _controller = new AccessController(service);
      _repository = repository;
      _options = options.Value;
      _faker = new Faker();
    }

    [Fact]
    public async Task Authentication_DebeRegresar_AcceptedResult()
    {
      var user = await _repository.Get(x => x.Active);
      var viewModel = new AccessViewModel { Email = user.Email, Password = user.Password };
      var result = await _controller.Authentication(viewModel);
      Assert.NotNull(result);
      Assert.IsType<AcceptedResult>(result);

      var objectResult = result as AcceptedResult;
      Assert.Equal(202, objectResult.StatusCode);
      Assert.IsType<AccessResponse>(objectResult.Value);

      var responseResult = objectResult.Value as AccessResponse;
      Assert.NotNull(responseResult);
      Assert.True(responseResult.Success);
      Assert.Equal(AccessResponse.AuthorizedMessage, responseResult.Message);
      Assert.IsType<AccessToken>(responseResult.Result);

      var itemResult = responseResult.Result as AccessToken;
      Assert.NotNull(itemResult);
      Assert.Equal(DateTime.Today, itemResult.Created.Date);
      Assert.Equal(DateTime.Now.AddMinutes(_options.Expiration), itemResult.Expiration
        , new TimeSpan(0, _options.Expiration, 0));

      //TODO: Token JWT Test;
    }

    [Fact]
    public async Task Authentication_DebeRegresar_BadRequestObjectResult()
    {
      var result = await _controller.Authentication(new AccessViewModel());
      Assert.NotNull(result);
      Assert.IsType<BadRequestObjectResult>(result);

      var objectResult = result as BadRequestObjectResult;
      Assert.Equal(400, objectResult.StatusCode);
      Assert.IsType<AccessResponse>(objectResult.Value);

      var responseResult = objectResult.Value as AccessResponse;
      Assert.NotNull(responseResult);
      Assert.Null(responseResult.Result);
      Assert.False(responseResult.Success);
      Assert.False(string.IsNullOrWhiteSpace(responseResult.Message));
    }

    [Fact]
    public async Task Authentication_DebeRegresar_InactiveUser_UnauthorizedObjectResult()
    {
      var user = await _repository.Get(x => !x.Active);
      var viewModel = new AccessViewModel { Email = user.Email, Password = user.Password };
      var result = await _controller.Authentication(viewModel);
      Assert.NotNull(result);
      Assert.IsType<UnauthorizedObjectResult>(result);

      var objectResult = result as UnauthorizedObjectResult;
      Assert.Equal(401, objectResult.StatusCode);
      Assert.IsType<AccessResponse>(objectResult.Value);

      var responseResult = objectResult.Value as AccessResponse;
      Assert.NotNull(responseResult);
      Assert.Null(responseResult.Result);
      Assert.False(responseResult.Success);
      Assert.Equal(TypeOfResponseUnauthorized.InactiveUser.GetString(), responseResult.Message);
    }

    [Fact]
    public async Task Authentication_DebeRegresar_InvalidPassword_UnauthorizedObjectResult()
    {
      var user = await _repository.Get(x => x.Active);
      var viewModel = new AccessViewModel
      {
        Email = user.Email,
        Password = _faker.Internet.Password(8)
      };
      var result = await _controller.Authentication(viewModel);
      Assert.NotNull(result);
      Assert.IsType<UnauthorizedObjectResult>(result);

      var objectResult = result as UnauthorizedObjectResult;
      Assert.Equal(401, objectResult.StatusCode);
      Assert.IsType<AccessResponse>(objectResult.Value);

      var responseResult = objectResult.Value as AccessResponse;
      Assert.NotNull(responseResult);
      Assert.Null(responseResult.Result);
      Assert.False(responseResult.Success);
      Assert.Equal(TypeOfResponseUnauthorized.InvalidPassword.GetString(), responseResult.Message);
    }

    [Fact]
    public async Task Authentication_DebeRegresar_UserNotFound_UnauthorizedObjectResult()
    {
      var viewModel = new AccessViewModel
      {
        Email = _faker.Internet.Email(),
        Password = _faker.Internet.Password(8)
      };
      var result = await _controller.Authentication(viewModel);
      Assert.NotNull(result);
      Assert.IsType<UnauthorizedObjectResult>(result);

      var objectResult = result as UnauthorizedObjectResult;
      Assert.Equal(401, objectResult.StatusCode);
      Assert.IsType<AccessResponse>(objectResult.Value);

      var responseResult = objectResult.Value as AccessResponse;
      Assert.NotNull(responseResult);
      Assert.Null(responseResult.Result);
      Assert.False(responseResult.Success);
      Assert.Equal(TypeOfResponseUnauthorized.NotFound.GetString(), responseResult.Message);
    }
  }
}