using Microsoft.AspNetCore.Mvc;

namespace HallodocMVC.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PatientRequest()
        {
            return View();
        }
        public IActionResult FamilyFriendRequest()
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
