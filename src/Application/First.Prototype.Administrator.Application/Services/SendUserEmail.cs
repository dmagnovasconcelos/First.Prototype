using System.Threading.Tasks;

using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Core.Configurations;
using First.Prototype.Core.Interfaces;
using First.Prototype.Core.Services;
using First.Prototype.Core.ViewModels;

using Microsoft.Extensions.Options;

namespace First.Prototype.Administrator.Application.Services
{
  public class SendUserEmail : SendEmail, ISendEmail<User>
  {
    public SendUserEmail(IOptions<EmailOptions> options)
      : base(options) { }

    public async Task SendEmailAsync(User entity)
    {
      var viewModel = EntityToSendEmailViewModel(entity);
      await Execute(viewModel).ConfigureAwait(false);
    }

    private SendEmailViewModel EntityToSendEmailViewModel(User entity)
    {
      return new(entity.Email
          , "Register New User"
          , $"Welcome!\r\nLogin: {entity.Email}\r\nPassword: {entity.Password}"
        );
    }
  }
}