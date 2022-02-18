using System.ComponentModel.DataAnnotations;

namespace EventFunTimesUI.Models
{
    public class EventResponse
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool Inside { get; set; }
        [Required]
        public bool Outside { get; set; }
        [Required]
        public ICollection<OpeningHoursResponse> OpeningHours { get; set; }
        [Url]
        public string? Link { get; set; }
    }
}
