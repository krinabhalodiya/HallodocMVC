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
        private readonly EmailConfiguration _emailConfig;
        public PatientRequestController(HalloDocContext context, EmailConfiguration emailConfig)
        {
            _context = context;
            _emailConfig = emailConfig;
        }

        public IActionResult Index()
        {
            return View("../Request/PatientRequest");
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmailAsync(string email)
        {
            string message;
            var aspnetuser = await _context.Aspnetusers.FirstOrDefaultAsync(m => m.Email == email);
            if (aspnetuser == null)
            {
                message = "False";
            }
            else
            {
                message = "Success";
            }
            return Json(new
            {
                isAspnetuser = aspnetuser == null
            });
        }


        public async Task<IActionResult> Create(ViewDataPatientRequest viewpatientcreaterequest)
        {
            var Aspnetuser = new Aspnetuser();
            var User = new User();
            var Request = new Request();
            var Requestclient = new Requestclient();
            var isexist = _context.Users.FirstOrDefault(x => x.Email == viewpatientcreaterequest.Email);
            if (isexist == null)
            {
                // Aspnetuser
                Guid g = Guid.NewGuid();
                Aspnetuser.Id = g.ToString();
                Aspnetuser.Username = viewpatientcreaterequest.Email;
                Aspnetuser.Passwordhash = viewpatientcreaterequest.LastName;
                Aspnetuser.CreatedDate = DateTime.Now;
                Aspnetuser.Email = viewpatientcreaterequest.Email;
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
            }

                Request.Requesttypeid = 1;
                Request.Status = 1;

            if (isexist == null)
            {
                Request.Userid = User.Userid;
            }else
            {
                Request.Userid = isexist.Userid;
            }
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
            Requestclient.Notes = viewpatientcreaterequest.Symptoms;

            _context.Requestclients.Add(Requestclient);
            await _context.SaveChangesAsync();

            if (viewpatientcreaterequest.UploadFile != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileNameWithPath = Path.Combine(path, viewpatientcreaterequest.UploadFile.FileName);
                viewpatientcreaterequest.UploadImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + viewpatientcreaterequest.UploadFile.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    viewpatientcreaterequest.UploadFile.CopyTo(stream);
                }

                var requestwisefile = new Requestwisefile
                {
                    Requestid = Request.Requestid,
                    Filename = viewpatientcreaterequest.UploadFile.FileName,
                    Createddate = DateTime.Now,
                };
                _context.Requestwisefiles.Add(requestwisefile);
                _context.SaveChanges();
            }


            return View("../Request/Index");
            //}

        }

    }
}
