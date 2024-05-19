using Cinema_Project.Models;
using System.Collections.Generic;

namespace Cinema_Project.ViewModels
{
    public class UserProfileViewModel
    {
        // Свойства пользователя для профиля
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        // Свойства для билетов пользователя
        public List<Ticket> Tickets { get; set; }
        public List<Movie> Movies { get; set; }

        // Конструктор для установки значений из модели AppUser и списка билетов
        public UserProfileViewModel(AppUser user, List<Ticket> tickets, List<Movie> movies)
        {
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            LastName = user.LastName;
            FirstName = user.FirstName;
            Tickets = tickets;
            Movies = movies;
        }
    }
}
