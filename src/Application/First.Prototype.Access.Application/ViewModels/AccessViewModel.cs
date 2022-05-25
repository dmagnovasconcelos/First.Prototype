using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using First.Prototype.Core.Utilities;

namespace First.Prototype.Access.Application.ViewModels
{
  public class AccessViewModel
  {
    private const string errorMessagePassword = @"Password must be between 8 and 20
                                                characters and contain one uppercase letter,
                                                one lowercase letter, one digit and one special character.";

    [Required(ErrorMessage = "The E-mail is Required")]
    [EmailAddress]
    [MaxLength(100)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The Password is Required")]
    [MinLength(8)]
    [MaxLength(20)]
    [DisplayName("Password")]
    [DataType(DataType.Password)]
    [RegularExpression(RegularExpressionUtility.PasswordRegularExpression, ErrorMessage = errorMessagePassword)]
    public string Password { get; set; }
  }
}