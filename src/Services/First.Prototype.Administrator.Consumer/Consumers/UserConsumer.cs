using System;
using System.Threading.Tasks;

using First.Prototype.Administrator.Domain.Entities;
using First.Prototype.Core.Interfaces;
using First.Prototype.Core.ViewModels;

using MassTransit;

namespace First.Prototype.Administrator.Consumer.Consumers
{
  public class UserConsumer : IConsumer<User>
  {
    private readonly ISendEmail<User> _sendEmail;

    public UserConsumer(ISendEmail<User> sendEmail)
    {
      _sendEmail = sendEmail;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
      try
      {
        await Console.Out.WriteLineAsync($"Send e-mail: {context.Message.Email}");
        await _sendEmail.SendEmailAsync(context.Message);
      }
      catch(Exception ex)
      {
        await Console.Out.WriteLineAsync(ex.Message);
      }
    }
  }
}