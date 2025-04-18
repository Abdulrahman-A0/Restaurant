namespace Resturant_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Payment Payment { get; set; }

        public ICollection<OrderDetail>? Details { get; set; }

    }
}
