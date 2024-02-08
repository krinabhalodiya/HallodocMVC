using HallodocMVC.DataContext;
using HallodocMVC.DataModels;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HallodocMVC.Controllers
{
    
    public class PatientRequestController : Controller
    {
        private readonly HalloDocContext _context;

        public PatientRequestController(HalloDocContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("../Request/PatientRequest");
        }

        public async Task<IActionResult> Create(ViewDataPatientRequest viewdata)
        {
            var A = new AspNetUser();
            A.Id = "1234";
                A.Email = viewdata.Email;
            A.UserName = "Krina";
                _context.AspNetUsers.Add(A);
                await _context.SaveChangesAsync();
            

            return View("../Request/Index");
        }

    }
}
