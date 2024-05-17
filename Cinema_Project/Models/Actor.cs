using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("actor")]
    public class Actor
    {
        [Key]
        [Column("actor_id")]
        public int ActorId { get; set; }

        [Column("firstname")]
        public string? FirstName { get; set; }

        [Column("lastname")]
        public string? LastName { get; set; }

        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
