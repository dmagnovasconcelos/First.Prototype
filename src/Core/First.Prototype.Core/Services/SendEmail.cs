using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using First.Prototype.Core.Configurations;
using First.Prototype.Core.Entities;
using First.Prototype.Core.ViewModels;

using Microsoft.Extensions.Options;

namespace First.Prototype.Core.Services
{
  public abstract class SendEmail<T> where T : Entity
  {
    private readonly EmailOptions _options;

    protected SendEmail(IOptions<EmailOptions> options)
    {
      _options = options.Value;
    }

    public async Task Execute(SendEmailViewModel viewModel)
    {
      var mail = new MailMessage()
      {
        From = new MailAddress(_options.UsernameEmail, _options.Sender)
      };

      mail.To.Add(new MailAddress(viewModel.Receiver));

      mail.Subject = viewModel.Subject;
      mail.Body = viewModel.Message;
      mail.IsBodyHtml = true;
      mail.Priority = MailPriority.High;

      try
      {
        using SmtpClient smtp = new(_options.PrimaryDomain, _options.PrimaryPort);
        smtp.Credentials = new NetworkCredential(_options.UsernameEmail, _options.UsernamePassword);
        smtp.EnableSsl = true;
        await smtp.SendMailAsync(mail);
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }
  }
}