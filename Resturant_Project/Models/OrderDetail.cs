using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
