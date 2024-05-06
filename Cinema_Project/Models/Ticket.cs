﻿using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Price { get; set; }
        [Column("showtime")]
        public DateTime Showtime { get; set; }
        [Column("hall")]
        public int Hall { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("hall_id")]
        public int HallId { get; set; }

        [Column("user_id")]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
