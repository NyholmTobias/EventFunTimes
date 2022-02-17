using System.ComponentModel.DataAnnotations;

namespace Projektarbete.Models
{
    public class OpeningHours
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Weekday { get; set; }

        [Range(0,23), Required]
        public int OpeningHour { get; set; }

        [Range(0, 23), Required]
        public int ClosingHour { get; set; }
        public Event? Event { get; set; }
    }
}
