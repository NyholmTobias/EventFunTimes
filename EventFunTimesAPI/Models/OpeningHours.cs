using System.ComponentModel.DataAnnotations;

namespace EventFunTimesAPI.Models
{
    public class OpeningHours
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Weekday { get; set; }

        [Range(0, 24), Required]
        public int OpeningHour { get; set; }

        [Range(0, 24), Required]
        public int ClosingHour { get; set; }
        public Event? Event { get; set; }
    }
}
