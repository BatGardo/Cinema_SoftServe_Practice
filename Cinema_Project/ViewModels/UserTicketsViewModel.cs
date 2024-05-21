using Cinema_Project.Models;
using System.Collections.Generic;

namespace Cinema_Project.ViewModels
{
    public class UserTicketsViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Movie> Movies { get; set; }

        public UserTicketsViewModel(AppUser user, List<Ticket> tickets, List<Movie> movies)
        {
            UserName = user.UserName;
            Email = user.Email;
            Tickets = tickets;
            Movies = movies;
        }
    }
}
