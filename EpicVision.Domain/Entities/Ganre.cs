
using System.ComponentModel.DataAnnotations;


namespace EpicVision.Domain.Entities
{
    public class Ganre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}
