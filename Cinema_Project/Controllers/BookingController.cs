using Cinema_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cinema_Project.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult BookingView()
        {
            int ticketId = 1;
            float price = 9.99f;
            DateTime showtime = new DateTime(2024, 5, 20, 19, 30, 0); // 20 мая 2024 года, 19:30
            int seatId = 45;
            int movieId = 12;
            int hallId = 3;
            string userId = "40759e95-6602-4de6-bc50-e04b468d1328";
            ticket_booking(ticketId, price, showtime, seatId, movieId, hallId, userId);

            return View();
        }

        public void ticket_booking(int TicketId, float Price, DateTime Showtime, int SeatId, int MovieId, int HallId, string UserId)
        {
            string connectionString = "Host=localhost;Database=cinemadb;Username=postgres;Password=2003;";

            string query = "INSERT INTO ticket (ticket_id, price, showtime, seat_id, movie_id, hall_id, user_id) " +
                           "VALUES (@TicketId, @Price, @Showtime, @SeatId, @MovieId, @HallId, @UserId);";

            // Создание и открытие подключения к базе данных
            using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(connectionString))
            {
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand(query, connection);

                // Добавление параметров с их значениями
                command.Parameters.AddWithValue("@TicketId", TicketId);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Showtime", Showtime);
                command.Parameters.AddWithValue("@SeatId", SeatId);
                command.Parameters.AddWithValue("@MovieId", MovieId);
                command.Parameters.AddWithValue("@HallId", HallId);
                command.Parameters.AddWithValue("@UserId", UserId);

                // Открытие подключения и выполнение команды
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
    public class TicketService
    {
        
    }
}
