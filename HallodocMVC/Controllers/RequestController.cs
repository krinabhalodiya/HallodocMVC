using Microsoft.AspNetCore.Mvc;

namespace HallodocMVC.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BusinessRequest()
        {
            return View();
        }
        public IActionResult ConciergeRequest()
        {
            return View();
        }
    }
        
}
