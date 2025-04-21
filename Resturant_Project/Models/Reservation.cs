using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableCount { get; set; }
        public string Descreption { get; set; }
        [ForeignKey("User")]

        public string UserId { get; set; }
        public User User { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
