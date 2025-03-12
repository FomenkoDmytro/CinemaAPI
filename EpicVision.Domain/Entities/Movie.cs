using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public int DurationInMinutes { get; set; }
    }
}
