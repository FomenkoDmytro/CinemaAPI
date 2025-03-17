using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpicVision.Domain.Entities
{
    public class Movie
    {
        [Key]
        [Column("movie_id")]
        public int Id { get; set; }

        [Required]
        [Column("movie_title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("movie_genre")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Column("movie_duration")]
        public int DurationInMinutes { get; set; }

        [Required]
        [Column("movie_description")]
        public string Description { get; set; } = string.Empty;
    }
}
