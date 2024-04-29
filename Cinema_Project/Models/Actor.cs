using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("actors")]
    public class Actor
    {
        [Key]
        [Column("actor_id")]
        public int ActorID { get; set; }
        [Column("lastname")]
        public string? LastName { get; set; }
        [Column("firstname")]
        public string? FirstName { get; set; }
        [Column("birthdate")]
        public DateTime BirthDate { get; set; }

        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
