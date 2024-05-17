using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("movie_genre")]
    public class MovieGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("movie_genre_id")]
        public int MovieGenreId { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        [Column("genre_id")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
