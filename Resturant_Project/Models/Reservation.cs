using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableCount { get; set; }
        public string? Description { get; set; }
        [ForeignKey("User")]

        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get; set; }
    }
}
