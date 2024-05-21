using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.ViewModels
{
    public class MovieAddVM
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? Duration { get; set; }
        public float? Rating { get; set; }

        public List<int>? SelectedGenreIds { get; set; }
        public List<int>? SelectedActorIds { get; set; }

        [Required] 
        public List<Genre> Genres { get; set; }
        [Required]
        public List<Actor> Actors { get; set; }
    }
}
