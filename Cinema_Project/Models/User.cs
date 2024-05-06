using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Cinema_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column("firstname")]
        public string? FirstName { get; set; }
        [Column("lastname")]
        public string? LastName { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
