namespace Restaurant_Project.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string Descreption { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
