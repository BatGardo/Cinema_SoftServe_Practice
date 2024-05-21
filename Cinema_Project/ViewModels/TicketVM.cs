using System;

namespace Cinema_Project.ViewModels
{
    public class TicketVM
    {
        public float? Price { get; set; }
        public DateTime Showtime { get; set; }
        public int? HallNumber { get; set; }
        public int? RowNumber { get; set; }
        public int? SeatNumber { get; set; }
        public int MovieId { get; set; }
        public string? UserId { get; set; }
    }
}
