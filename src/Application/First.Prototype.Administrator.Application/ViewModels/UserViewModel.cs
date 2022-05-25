using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using First.Prototype.Core.Interfaces;

namespace First.Prototype.Administrator.Application.ViewModels
{
  public class UserViewModel : IViewModel
  {
    [Required]
    public bool Active { get; set; }

    [Required(ErrorMessage = "The BirthDate is Required")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "The E-mail is Required")]
    [EmailAddress]
    [MaxLength(100)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The First Name is Required")]
    [MinLength(2)]
    [MaxLength(50)]
    public string FirstName { get; set; }

    public Guid Id { get; set; }

    [Required(ErrorMessage = "The Last Name is Required")]
    [MinLength(2)]
    [MaxLength(50)]
    public string LastName { get; set; }

    public string NickName { get; set; }

    public UserViewModel()
    {
      Id = Guid.NewGuid();
      Active = true;
    }

    public UserViewModel(Guid id
      , bool active
      , string email
      , string firstName
      , string lastName
      , string nickName
      , DateTime birthDate)
    {
      Id = id;
      Active = active;
      Email = email;
      FirstName = firstName;
      LastName = lastName;
      NickName = nickName;
      BirthDate = birthDate;
    }
  }
}