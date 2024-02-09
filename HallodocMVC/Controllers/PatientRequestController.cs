using System.Collections;
using HallodocMVC.DataContext;
using HallodocMVC.DataModels;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

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


        public async Task<IActionResult> Create(ViewDataPatientRequest viewpatientcreaterequest)
        {
            var Aspnetuser = new Aspnetuser();
            var User = new User();
            var Request = new Request();
            var Requestclient = new Requestclient();


            //if (viewpatientcreaterequest.UserName != null && viewpatientcreaterequest.PassWord != null)
            //{
            // Aspnetuser
                Guid g = Guid.NewGuid();
                Aspnetuser.Id = g.ToString();
                Aspnetuser.Username = viewpatientcreaterequest.FirstName;
                Aspnetuser.Passwordhash = viewpatientcreaterequest.LastName;
                Aspnetuser.CreatedDate = DateTime.Now;
                _context.Aspnetusers.Add(Aspnetuser);
                await _context.SaveChangesAsync();

                User.Aspnetuserid = Aspnetuser.Id;
                User.Firstname = viewpatientcreaterequest.FirstName;
                User.Lastname = viewpatientcreaterequest.LastName;
                User.Email = viewpatientcreaterequest.Email;
                User.Createdby = Aspnetuser.Id;
                User.Createddate = DateTime.Now;
                _context.Users.Add(User);
                await _context.SaveChangesAsync();

                Request.Requesttypeid = 2;
                Request.Userid = User.Userid;
                Request.Firstname = viewpatientcreaterequest.FirstName;
                Request.Lastname = viewpatientcreaterequest.LastName;
                Request.Email = viewpatientcreaterequest.Email;
                Request.Phonenumber = viewpatientcreaterequest.PhoneNumber;
                Request.Isurgentemailsent = new BitArray(1);
                Request.Createddate = DateTime.Now;
                _context.Requests.Add(Request);
                await _context.SaveChangesAsync();

                Requestclient.Requestid = Request.Requestid;
                Requestclient.Firstname = viewpatientcreaterequest.FirstName;
                Requestclient.Address = viewpatientcreaterequest.Street;
                Requestclient.Lastname = viewpatientcreaterequest.LastName;
                Requestclient.Email = viewpatientcreaterequest.Email;
                Requestclient.Phonenumber = viewpatientcreaterequest.PhoneNumber;

                _context.Requestclients.Add(Requestclient);
                await _context.SaveChangesAsync();
                return View("../Request/Index");
            //}

        }

    }
}
