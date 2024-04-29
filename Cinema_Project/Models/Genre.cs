using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("genres")]
    public class Genre
    {
        [Key]
        [Column("genre_id")]
        public int GenreId { get; set; }
        [Column("title")]
        public string? Title { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }
    }
}
