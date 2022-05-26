namespace First.Prototype.Core.Configurations
{
  public class EmailOptions
  {
    public string PrimaryDomain { get; set; }
    public int PrimaryPort { get; set; }
    public string Sender { get; set; }
    public string UsernameEmail { get; set; }
    public string UsernamePassword { get; set; }
  }
}