using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cinema_Project.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("lastname")]
        public string? LastName { get; set; }
        [Column("firstname")]
        public string? FirstName { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("phone")]
        public string? Phone { get; set; }
        [Column("birthdate")]
        public DateTime BirthDate { get; set; }
        [Column("login")]
        public string? Login { get; set; }
        [Column("password")]
        public string? Password { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
