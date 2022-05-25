namespace First.Prototype.Core.Configurations
{
  public class QueryDbOptions
  {
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public bool IsSSL { get; set; }
  }
}