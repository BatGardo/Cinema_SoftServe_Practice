using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Cinema_Project.Models
{
    [Table("users")]
    public class AppUser : IdentityUser
    {
        [Column("lastname")]
        public string? LastName { get; set; }
        [Column("firstname")]
        public string? FirstName { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

    }
}
