

using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class Audience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}
