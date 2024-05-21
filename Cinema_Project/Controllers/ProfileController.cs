using Microsoft.AspNetCore.Mvc;
using Cinema_Project.ViewModels;
using Cinema_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Text;
using System.IO;

namespace Cinema_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ProfileView()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                string userName = HttpContext.Session.GetString("UserName");

                var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    var tickets = _context.Tickets
                        .Where(t => t.UserId == user.Id)
                        .Include(t => t.Movie)
                        .Include(t => t.User)
                        .ToList();

                    var profileViewModel = new UserProfileViewModel(user, tickets, null);

                    ViewBag.UserName = profileViewModel.UserName;
                    ViewBag.Email = profileViewModel.Email;


                    return View(profileViewModel);
                }
            }

            return RedirectToAction("Login", "Account");
        }
        public IActionResult GeneratePDF(string movieTitle, DateTime showtime, int rowNumber, int seatNumber, int hallNumber, decimal price)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);


            //XFont font = new XFont("Arial", 12);
            string ticketInfo = $"Movie: {movieTitle}\nShowtime: {showtime}\nRow Number: {rowNumber}\nSeat Number: {seatNumber}\nHall Number: {hallNumber}\nPrice: {price}";
            //gfx.DrawString(ticketInfo, font, XBrushes.Black, new XPoint(40, 40));

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "ticket.pdf");

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encoding = Encoding.GetEncoding("windows-1251");

                document.Save(stream, closeStream: false);
            }



            document.Close();

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "ticket.pdf");
        }

    }
}
