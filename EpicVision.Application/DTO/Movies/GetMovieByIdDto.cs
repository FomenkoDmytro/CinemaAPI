using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.DTO.Movies
{
    public class GetMovieByIdDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string TrailerUrl { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }

        public int Duration { get; set; }

        public int DurationUnitId { get; set; }
        public DurationUnit? DurationUnit { get; set; }

        public string Plot { get; set; } = string.Empty;

        public int AudienceId { get; set; }
        public Audience? Audience { get; set; }

        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }

        public List<Actor> Actors { get; set; } = new();

        public List<Ganre> Ganres { get; set; } = new();

        public List<Language> Languages { get; set; } = new();

        public List<Session> Sessions { get; set; } = new();
    }
}
