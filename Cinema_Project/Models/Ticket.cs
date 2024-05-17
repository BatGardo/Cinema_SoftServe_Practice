using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("ticket")]
    public class Ticket
    {
        [Key]
        [Column("ticket_id")]
        public int TicketId { get; set; }
        [Column("price")]
        public float? Price { get; set; }
        [Column("showtime")]
        public DateTime Showtime { get; set; }
        [Column("hall_number")]
        public int? HallNumber { get; set; }
        [Column("row_number")]
        public int? RowNumber { get; set; }
        [Column("seat_number")]
        public int? SeatNumber { get; set; }
        
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("user_id")]
        public string? UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
