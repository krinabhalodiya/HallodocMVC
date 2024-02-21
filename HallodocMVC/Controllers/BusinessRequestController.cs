using System.Collections;
using HallodocMVC.DataContext;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HallodocMVC.DataModels;

namespace HallodocMVC.Controllers
{
    public class BusinessRequestController : Controller
    {
        private readonly HalloDocContext _context;

        public BusinessRequestController(HalloDocContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("../Request/BusinessRequest");
        }
		public async Task<IActionResult> Create(ViewDataBusinessRequest viewdata)
        {
            /*if (ModelState.IsValid)
            {*/


                //var region = _context.Regions.FirstOrDefault(u => u.Name == viewdata.State.Trim().ToLower().Replace(" ", ""));
                //if (region == null)
                //{
                //    ModelState.AddModelError("State", "Currently we are not serving in this region");
                //    return View("../Request/PatientRequestForm", viewdata);
                //}
                int requests = _context.Requests.Where(u => u.Createddate == DateTime.Now.Date).Count();
                //string ConfirmationNumber = string.Concat(region.Abbreviation, viewdata.FirstName.Substring(0, 2).ToUpper(), viewdata.LastName.Substring(0, 2).ToUpper(), viewdata.LastName.Substring(0, 2).ToUpper(), requests.ToString("D" + 4));
                var Business = new Business();
                var Request = new Request();
                var Requestclient = new Requestclient();
                var Requestbusiness = new Requestbusiness();
                Random _random = new Random();

                Business.Name = viewdata.BUP_FirstName + viewdata.BUP_LastName;
                Business.Createddate = DateTime.Now;
                _context.Businesses.Add(Business);
                await _context.SaveChangesAsync();
                int id1 = Business.Businessid;


                Request.Requesttypeid = 3;
                Request.Status = 1;
                Request.Firstname = viewdata.FirstName;
                Request.Lastname = viewdata.LastName;
                Request.Email = viewdata.Email;
                Request.Phonenumber = viewdata.PhoneNumber;
                Request.Isurgentemailsent = new BitArray(1);
                Request.Createddate = DateTime.Now;
                //Request.Confirmationnumber = ConfirmationNumber;
                _context.Requests.Add(Request);
                await _context.SaveChangesAsync();
                int id2 = Request.Requestid;

                Requestclient.Requestid = Request.Requestid;
                Requestclient.Firstname = viewdata.FirstName;
                Requestclient.Lastname = viewdata.LastName;
                Requestclient.Email = viewdata.Email;
                Requestclient.Phonenumber = viewdata.PhoneNumber;
                _context.Requestclients.Add(Requestclient);
                await _context.SaveChangesAsync();

                Requestbusiness.Requestid = id2;
                Requestbusiness.Businessid = id1;
                _context.Requestbusinesses.Add(Requestbusiness);
                await _context.SaveChangesAsync();
            /*}
            else
            {
                return View("../Request/BusinessRequest", viewdata);
            }*/
            return View("../Request/Index");
        }
    }
}
