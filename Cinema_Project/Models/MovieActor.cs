using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.Models
{
    [Table("movie_actor")]
    public class MovieActor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("movie_actor_id")]
        public int MovieActorId { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        [Column("actor_id")]
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
