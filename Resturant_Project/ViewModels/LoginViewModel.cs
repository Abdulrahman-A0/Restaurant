using System.ComponentModel.DataAnnotations;

namespace Restaurant_Project.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Emial")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
