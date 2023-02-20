using Microsoft.AspNetCore.Mvc;
using Progress.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Progress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string userPhone)
        {
            var fromEmail = new MailAddress("alibalagakimov@gmail.com", "Служба поддержки Venbox");
            var toEmail = new MailAddress("kamalbajramov75@gmail.com");
            var fromEmailPassword = "oymlhncumibrecrw"; // Replace with password
            string subject = "Добро пожаловать";
            string body = userName + " " + userPhone;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}