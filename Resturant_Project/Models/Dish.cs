﻿namespace Resturant_Project.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double AverageRate { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}
