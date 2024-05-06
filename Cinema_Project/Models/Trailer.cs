using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("trailer")]
    public class Trailer
    {
        [Key]
        [Column("trailer_id")]
        public int TrailerId { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("url")]
        public string? Url { get; set; }
        
        [Column("movie_id")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
