using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Restaurant_Project.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public Cart? Cart { get; set; }

    }
}
