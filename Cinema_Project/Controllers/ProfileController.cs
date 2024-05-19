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
                    // Получаем список билетов, связанных с пользователем, по его ID
                    var tickets = _context.Tickets
                        .Where(t => t.UserId == user.Id)
                        .Include(t => t.Movie)
                        .Include(t => t.User) // Включаем данные о пользователе
                        .ToList();

                    var profileViewModel = new UserProfileViewModel(user, tickets, null); // Вторым аргументом передается null, так как список фильмов пока не передается

                    ViewBag.UserName = profileViewModel.UserName;
                    ViewBag.Email = profileViewModel.Email;
                    //ViewBag.Password = profileViewModel.Password;
                    //ViewBag.UserName = profileViewModel.UserName;

                    return View(profileViewModel);
                }
            }

            return RedirectToAction("Login", "Account");
        }
        public IActionResult GeneratePDF(string movieTitle, DateTime showtime, int rowNumber, int seatNumber, int hallNumber, decimal price)
        {
            // Создание нового PDF-документа
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Остальной код для создания содержимого документа
            // Например, добавление информации о билете
            //XFont font = new XFont("Arial", 12);
            string ticketInfo = $"Movie: {movieTitle}\nShowtime: {showtime}\nRow Number: {rowNumber}\nSeat Number: {seatNumber}\nHall Number: {hallNumber}\nPrice: {price}";
            //gfx.DrawString(ticketInfo, font, XBrushes.Black, new XPoint(40, 40));

            // Путь для сохранения PDF-документа
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "ticket.pdf");

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                // Устанавливаем кодировку для сохранения
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encoding = Encoding.GetEncoding("windows-1251"); // Или другую подходящую кодировку

                // Сохраняем PDF-документ с указанной кодировкой
                document.Save(stream, closeStream: false);
            }



            // Освобождение ресурсов
            document.Close();

            // Возвращаем результат как файл для скачивания
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "ticket.pdf");
        }

    }
}
