using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("tickets")]
    public class Ticket
    {
        [Key]
        [Column("ticket_id")]
        public int TicketId { get; set; }
        [Column("price")]
        public string? Price { get; set; }
        [Column("showtime")]
        public DateTime Showtime { get; set; }
        [Column("hall")]
        public int Hall { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }
    }
}
