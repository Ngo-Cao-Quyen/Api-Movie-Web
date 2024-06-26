﻿
using Api.Dtos.MovieEpisode;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Dtos.MovieSeries
{
    public class MovieSeriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PosterPath { get; set; }
        public IFormFile ImageFile { get; set; }
        public int TotalEpisode { get; set; }
        public int TotalNumberofViewers { get; set; }
        public int RegionId { get; set; }
        public int YearId { get; set; }
        public int[] GenreIds { get; set; }
        public List<MovieEpisodeDto> Episodes { get; set; }
    }
}
