using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("duration")]
        public DateTime Duration { get; set; }
        [Column("rating")]
        public float Rating { get; set; }

        public ICollection<Trailer>? Trailers { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<MovieGenre>? MovieGenres { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
