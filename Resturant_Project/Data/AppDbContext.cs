using Microsoft.EntityFrameworkCore;
using Resturant_Project.Models;

namespace Resturant_Project.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                  .Build();

            var connectionString = configuration.GetConnectionString("Constr");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
