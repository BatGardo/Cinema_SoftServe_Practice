using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("screening")]
    public class Screening
    {
        [Key]
        [Column("screening_id")]
        public int ScreeningId { get; set; }
        [Column("screening_date")]
        public DateTime ScreeningDate { get; set; }
        [Column("hall_number")]
        public int? HallNumber { get; set; }
        [Column("price")]
        public float? Price { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
