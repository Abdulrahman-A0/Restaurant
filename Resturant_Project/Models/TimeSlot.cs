namespace Resturant_Project.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Capacity { get; set; }
        public int Available { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}
