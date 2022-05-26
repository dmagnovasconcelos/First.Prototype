namespace First.Prototype.Core.ViewModels
{
  public class SendEmailViewModel
  {
    public string Message { get; }
    public string Receiver { get; }
    public string Subject { get; }

    public SendEmailViewModel(string receiver
      , string subject
      , string message)
    {
      Receiver = receiver;
      Subject = subject;
      Message = message;
    }
  }
}