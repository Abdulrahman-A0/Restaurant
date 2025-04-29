using System.ComponentModel.DataAnnotations;

namespace Restaurant_Project.ViewModels
{
    public class UserProfileViewModel
    {
        public string Email { get; set; }
        [Required]
        public string Image { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Phone")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Your Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Enter Your New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
