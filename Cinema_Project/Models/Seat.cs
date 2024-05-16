using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("seat")]
    public class Seat
    {
        [Key]
        [Column("seat_id")]
        public int SeatId { get; set; }
        [Column("row_number")]
        public int RowNumber { get; set; }
        [Column("seat_number")]
        public int SeatNumber { get; set; }
        [Column("is_reserved")]
        public bool IsReserved { get; set; }

        [Column("hall_id")]
        public int HallId { get; set; }
    }
    
}
