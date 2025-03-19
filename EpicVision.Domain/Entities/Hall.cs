
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        //https://localhost:7216/images/halls/CinemaHall1.jpg

        public List<Movie> Movies { get; set; } = new();

        public List<Session> Sessions { get; set; } = new();
    }
}
