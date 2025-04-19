namespace Restaurant_Project.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
