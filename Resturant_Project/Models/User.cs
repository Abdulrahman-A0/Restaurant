using System.ComponentModel;

namespace Restaurant_Project.Models
{

    public enum UserRole
    {
        Customer,
        Admin
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
