using System.Collections.Generic;
using Cinema_Project.Models;

namespace Cinema_Project.ViewModels
{
    public class CombinedScreeningMovieViewModel
    {
        public List<Screening> Screenings { get; set; }
        public List<Movie> Movies { get; set; }
    }
}