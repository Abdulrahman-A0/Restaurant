using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public enum PaymentMethod
    {
        Cash
    }
    public class Payment
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool Status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}
