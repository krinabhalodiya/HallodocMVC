using Microsoft.AspNetCore.Mvc;

namespace HallodocMVC.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
