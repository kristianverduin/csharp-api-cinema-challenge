﻿using api_cinema_challenge.Models.DTOs.Movie;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("rating")]
        public string? Rating { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("runtime")]
        public int Runtime { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();

        public static MovieResponseDTO ToDTO(Movie movie)
        {
            var movieDTO = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Rating = movie.Rating,
                Description = movie.Description,
                Runtime = movie.Runtime,
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt
            };

            return new MovieResponseDTO { Data= movieDTO };
        }

        public static MovieResponseListDTO ToDTO(ICollection<Movie> movies)
        {
            List<MovieDTO> moviesDTO = new List<MovieDTO>();
            foreach (var movie in movies)
            {
                moviesDTO.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Rating = movie.Rating,
                    Description = movie.Description,
                    Runtime = movie.Runtime,
                    CreatedAt = movie.CreatedAt,
                    UpdatedAt = movie.UpdatedAt
                });
            } 

            return new MovieResponseListDTO { Data = moviesDTO };
        }
    }
}
