namespace Cinema_Project.ViewModels
{
	public class ScreenVM
	{
		public int Id { get; set; } // Add the Id property
		public string MovieTitle { get; set; }
		public int HallName { get; set; }
		public string Date { get; set; }
		public int Time { get; set; }
		public int Price { get; set; }
		public DateTime ScreeningDate { get; set; }
	}
}
