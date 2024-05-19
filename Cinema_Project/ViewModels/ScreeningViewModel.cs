using System;

namespace Cinema_Project.ViewModels
{
    public class ScreeningViewModel
    {
        public int Id { get; set; } // Add the Id property
        public string MovieTitle { get; set; }
        public string HallName { get; set; }
        public DateTime ScreeningDate { get; set; }
    }
}