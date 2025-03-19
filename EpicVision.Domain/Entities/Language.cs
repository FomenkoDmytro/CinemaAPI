
using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LanguageName { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}
