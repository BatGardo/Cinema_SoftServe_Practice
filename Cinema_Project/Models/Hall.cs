using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_Project.Models
{
    [Table("hall")]
    public class Hall
    {
        [Key]
        [Column("hall_id")]
        public int HallId { get; set; }
        [Column("hall_number")]
        public int? HallNumber { get; set; }
        [Column("seat_count")]
        public int? SeatCount { get; set; }
        [Column("is_reserved")]
        public bool? IsReserved { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Seat>? Seats { get; set; }
    }
}
