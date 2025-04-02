using EpicVision.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.DTO.Movies
{
    public class MoviesFromDateTime
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }

        public int Duration { get; set; }

        public DurationUnit DurationUnit { get; set; }

        public string Plot { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Producer { get; set; } = string.Empty;

        //public List<Hall> Halls { get; set; } = new();

        public List<Actor> Actors { get; set; } = new();

        public List<Ganre> Ganres { get; set; } = new();

        public List<Language> Languages { get; set; } = new();

        public List<Session> Sessions { get; set; } = new();
    }
}
