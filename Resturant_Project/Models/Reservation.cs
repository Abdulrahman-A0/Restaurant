namespace Resturant_Project.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableCount { get; set; }
        public string Descreption { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
