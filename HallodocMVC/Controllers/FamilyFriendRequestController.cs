using System.Collections;
using HallodocMVC.DataContext;
using HallodocMVC.DataModels;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HallodocMVC.Controllers
{
    public class FamilyFriendRequestController : Controller
    {
        private readonly HalloDocContext _context;

        public FamilyFriendRequestController(HalloDocContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View("../Request/FamilyFriendRequest");
        }
        public async Task<IActionResult> Create(ViewDataFamilyFriendRequest viewDataFamilyFriendRequest)
        {
            var Request = new Request
            {
                Requesttypeid = 2,
                Status = 1,
                Firstname = viewDataFamilyFriendRequest.FF_FirstName,
                Lastname = viewDataFamilyFriendRequest.FF_LastName,
                Email = viewDataFamilyFriendRequest.FF_Email,
                Relationname = viewDataFamilyFriendRequest.FF_RelationWithPatient,
                Phonenumber = viewDataFamilyFriendRequest.FF_PhoneNumber,
                Createddate = DateTime.Now,
                Isurgentemailsent = new BitArray(1)

            };
            _context.Requests.Add(Request);
            await _context.SaveChangesAsync();

            var Requestclient = new Requestclient
            {
                Request = Request,
                Requestid = Request.Requestid,
                Notes = viewDataFamilyFriendRequest.Symptoms,
                Firstname = viewDataFamilyFriendRequest.FirstName,
                Lastname = viewDataFamilyFriendRequest.LastName,
                Phonenumber = viewDataFamilyFriendRequest.PhoneNumber,
                Email = viewDataFamilyFriendRequest.Email,
                State = viewDataFamilyFriendRequest.State,
                City = viewDataFamilyFriendRequest.City,
                Zipcode = viewDataFamilyFriendRequest.ZipCode

            };
            _context.Requestclients.Add(Requestclient);
            await _context.SaveChangesAsync();
            return View("../Request/Index");
        }
    }
}
