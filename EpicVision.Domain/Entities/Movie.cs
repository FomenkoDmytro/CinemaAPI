using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public string Description { get; set; } = string.Empty;

        public List<Ganres> Ganres { get; set; } = new();
    }
}
