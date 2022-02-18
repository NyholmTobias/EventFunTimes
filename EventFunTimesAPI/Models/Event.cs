using System.ComponentModel.DataAnnotations;

namespace EventFunTimesAPI.Models
{
    public class Event
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
        public ICollection<OpeningHours> OpeningHours { get; set; }
        public string? Link { get; set; }
    }
}
