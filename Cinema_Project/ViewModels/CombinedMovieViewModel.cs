using Cinema_Project.Models;

namespace Cinema_Project.ViewModels
{
    public class CombinedMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Trailer> Trailers { get; set; }
        public List<Screening> Screenings { get; set; }
    }
}
