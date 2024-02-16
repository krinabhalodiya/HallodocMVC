using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using HallodocMVC.DataContext;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HallodocMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly HalloDocContext _context;
        private readonly EmailConfiguration _emailConfig;
        public HomeController(HalloDocContext context, EmailConfiguration emailConfig)
        {
            _context = context;
            _emailConfig = emailConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()

        {
            return View();
        }

        public IActionResult Forgotpass()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult ChangePassword(string email, string datetime)
        {
            Encyptdecypt en = new Encyptdecypt();
            

            TempData["email"] = en.DecryptString(email);
            TimeSpan time = DateTime.Now - en.DecryptDate(datetime);
            if (time.TotalHours > 24)
            {
                return View("LinkExpired");
            }
            else
            {
                return View("resetpassword");
            }

        }
        [HttpPost]
        public IActionResult SavePassword(string email, string Password)
        {
            //var hasher = new PasswordHasher<string>();
            //string hashedPassword = hasher.HashPassword(null, Password);

            var aspnetuser = _context.Aspnetusers.FirstOrDefault(m => m.Email == email);
            if (aspnetuser != null)
            {
                aspnetuser.Passwordhash = Password;
                _context.Aspnetusers.Update(aspnetuser);
                _context.SaveChangesAsync();

                TempData["emailmassage"] = "Your password is changed!!";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["emailmassage"] = "Email is not registered!!";
                return View("ResetPassword");
            }
        }
        public async Task<IActionResult> resetEmailAsync(string Email)
        {
            if (await CheckregisterdAsync(Email))
            {
                var aspnetuser = await _context.Aspnetusers.FirstOrDefaultAsync(m => m.Email == Email);
                aspnetuser.Passwordhash = generatepass();
                aspnetuser.Modifieddate = DateTime.Now;
                try
                {
                    _context.Update(aspnetuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspnetuserExists(aspnetuser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                Encyptdecypt encyptdecypt = new Encyptdecypt();
                string encyptemail = encyptdecypt.EnryptString(Email);
                DateTime dateTime = DateTime.Now;
                string encyptdatetime = encyptdecypt.EncryptDate(DateTime.Now);
                string resetLink = $"https://localhost:44352/Home/ChangePassword?email={encyptemail}&datetime={encyptdatetime}";

                //send mail
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_emailConfig.From);
                message.Subject = "Change PassWord";
                message.To.Add(new MailAddress(Email));
                message.Body = $@"
                <html>
                <body>
                    <p>We received a request to reset your password.</p>
                    <p>To reset your password, click the following link:</p>
                    <p><a href=""{resetLink}"">Reset Password</a></p>
                    <p>If you didn't request a password reset, you can ignore this email.</p>
                </body>
                </html>";
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient(_emailConfig.SmtpServer))
                {
                    smtpClient.Port = _emailConfig.Port;
                    smtpClient.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                }
                ViewData["EmailCheck"] = "Your ID Pass Send In Your Mail";
            }
            else
            {
                ViewData["EmailCheck"] = "Your Email Is not registered";
                return View("ResetPassword");
            }



            return RedirectToAction("Index", "Dashboard");
        }
        private bool AspnetuserExists(string id)
        {
            return (_context.Aspnetusers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<bool> CheckregisterdAsync(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (!string.IsNullOrEmpty(email) && Regex.IsMatch(email, pattern))
            {

                var U = await _context.Aspnetusers.FirstOrDefaultAsync(m => m.Email == email);
                if (U != null)
                {
                    return true;
                }
            }

            return false;
        }
        private static Random random = new Random();
        public static string generatepass()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
