using System.ComponentModel.DataAnnotations;

namespace Restaurant_Project.ViewModels
{
    public class BookTableViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Duration must be between 1 and 10 hours")]
        public int Duration { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "You must book at least 1 table & at most 20 tables")]
        public int TableCount { get; set; }

        public string? Description { get; set; }
    }
}
