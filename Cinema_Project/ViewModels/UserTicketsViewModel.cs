using Cinema_Project.Models;
using System.Collections.Generic;

namespace Cinema_Project.ViewModels
{
    public class UserTicketsViewModel
    {
        // Свойства пользователя
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Movie> Movies { get; set; }

        // Конструктор для установки значений из модели AppUser и списка билетов
        public UserTicketsViewModel(AppUser user, List<Ticket> tickets, List<Movie> movies)
        {
            UserName = user.UserName;
            Email = user.Email;
            Tickets = tickets;
            Movies = movies;
        }
    }
}
