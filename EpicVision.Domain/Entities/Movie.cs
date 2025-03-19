using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpicVision.Domain.Entities
{
    public enum DurationUnit
    {
        Minutes,
        Hours
    }

    public class Movie
    {


        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        //https://localhost:7216/images/halls/CinemaHall1.jpg

        public DateOnly StartDate { get; set; }

        public int Duration { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string Plot { get; set; } = string.Empty;

        public int AudienceId { get; set; }
        public Audience? Audience { get; set; }

        public int ProducerId {  get; set; }
        public Producer? Producer { get; set; }

        public List<Hall> Halls { get; set; } = new();

        public List<Actor> Actors { get; set; } = new();

        public List<Ganre> Ganres { get; set; } = new();

        public List<Language> Languages { get; set; } = new();
    }
}
