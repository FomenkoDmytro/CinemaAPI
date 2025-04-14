using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.DTO.Movies
{
    public class AddMovieDto
    {
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string TrailerUrl { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public int Duration { get; set; }

        public int DurationUnitId { get; set; }

        public string Plot { get; set; } = string.Empty;

        public int AudienceId { get; set; }

        public int ProducerId { get; set; }

        public int LanguageId { get; set; }

        public List<ActorShortDto> Actors { get; set; } = new();

        public List<GanreShortDto> Ganres { get; set; } = new();

        public List<SessionShortDto>? Sessions { get; set; } = new();
    }
}
