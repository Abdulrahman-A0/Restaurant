using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]

        public string UserId { get; set; }
        public User User { get; set; }

        public Payment Payment { get; set; }

        public ICollection<OrderDetail>? Details { get; set; }

    }
}
