using System.Collections;
using HallodocMVC.DataContext;
using HallodocMVC.DataModels;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HallodocMVC.Controllers
{
    public class RequestByPatient : Controller
    {
        private readonly HalloDocContext _context;

        public RequestByPatient(HalloDocContext context)
        {
            _context = context;
        }
        public IActionResult RequestForMe()
        {
            var ViewDataPatientRequest = _context.Users
                               .Where(r => Convert.ToString(r.Aspnetuserid) == (CV.UserID()))
                               .Select(r => new ViewDataPatientRequest
                               {
                                   FirstName = r.Firstname,
                                   LastName = r.Lastname,
                                   Email = r.Email,
                                   PhoneNumber = r.Mobile,
                                   BirthDate = new DateTime((int)r.Intyear, Convert.ToInt32(r.Strmonth.Trim()), (int)r.Intdate)
                               })
                               .FirstOrDefault();
            return View(ViewDataPatientRequest);
        }
        public IActionResult RequestForSomeoneelse()
        {
            return View();
        }

        #region PostSomeoneElseAsync
        public async Task<IActionResult> PostMe(ViewDataPatientRequest viewpatientrequestforme)
        {
            //if (ModelState.IsValid)
            //{

                var Request = new Request();
                var Requestclient = new Requestclient();

                Request.Requesttypeid = 2;
                var isexist = _context.Users.FirstOrDefault(x => x.Email == viewpatientrequestforme.Email);
                Request.Userid = isexist.Userid;
                Request.Firstname = viewpatientrequestforme.FirstName;
                Request.Lastname = viewpatientrequestforme.LastName;
                Request.Email = viewpatientrequestforme.Email;
                Request.Phonenumber = viewpatientrequestforme.PhoneNumber;
                Request.Isurgentemailsent = new BitArray(1);
                Request.Createddate = DateTime.Now;
                _context.Requests.Add(Request);
                await _context.SaveChangesAsync();

                Requestclient.Requestid = Request.Requestid;
                Requestclient.Firstname = viewpatientrequestforme.FirstName;
                Requestclient.Address = viewpatientrequestforme.Street;
                Requestclient.Lastname = viewpatientrequestforme.LastName;
                Requestclient.Email = viewpatientrequestforme.Email;
                Requestclient.Phonenumber = viewpatientrequestforme.PhoneNumber;
                //Requestclient.Latitude = viewpatientrequestforme.latitude;
                //Requestclient.Longitude = viewpatientrequestforme.longitude;

                _context.Requestclients.Add(Requestclient);
                await _context.SaveChangesAsync();


                if (viewpatientrequestforme.UploadFile != null)
                {
                    string FilePath = "wwwroot\\Upload";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    string fileNameWithPath = Path.Combine(path, viewpatientrequestforme.UploadFile.FileName);
                    viewpatientrequestforme.UploadImage = viewpatientrequestforme.UploadFile.FileName;

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        viewpatientrequestforme.UploadFile.CopyTo(stream);
                    }

                    var requestwisefile = new Requestwisefile
                    {
                        Requestid = Request.Requestid,
                        Filename = viewpatientrequestforme.UploadImage,
                        Createddate = DateTime.Now,
                    };
                    _context.Requestwisefiles.Add(requestwisefile);
                    _context.SaveChanges();
                }
            //}
            //else
            //{
            //    return View("../RequestByPatient/SubmitForMe", viewpatientrequestforme);
            //}
            return RedirectToAction("Index", "Dashboard");
        }
        #endregion


        #region PostSomeoneElseAsync
        public async Task<IActionResult> PostSomeoneElse(ViewDataPatientRequest viewpatientrequestforme)
        {
            if (ModelState.IsValid)
            {
                var Request = new Request();
                var Requestclient = new Requestclient();

                Request.Requesttypeid = 2;
                Request.Userid = Convert.ToInt32(CV.UserID());
                Request.Firstname = viewpatientrequestforme.FirstName;
                Request.Lastname = viewpatientrequestforme.LastName;
                Request.Email = viewpatientrequestforme.Email;
                Request.Phonenumber = viewpatientrequestforme.PhoneNumber;
                Request.Relationname = viewpatientrequestforme.FF_RelationWithPatient;
                Request.Isurgentemailsent = new BitArray(1);
                Request.Createddate = DateTime.Now;
                _context.Requests.Add(Request);
                await _context.SaveChangesAsync();

                Requestclient.Requestid = Request.Requestid;
                Requestclient.Firstname = viewpatientrequestforme.FirstName;
                Requestclient.Address = viewpatientrequestforme.Street;
                Requestclient.Lastname = viewpatientrequestforme.LastName;
                Requestclient.Email = viewpatientrequestforme.Email;
                Requestclient.Phonenumber = viewpatientrequestforme.PhoneNumber;

                _context.Requestclients.Add(Requestclient);
                await _context.SaveChangesAsync();


                if (viewpatientrequestforme.UploadFile != null)
                {
                    string FilePath = "wwwroot\\Upload";
                    string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    string fileNameWithPath = Path.Combine(path, viewpatientrequestforme.UploadFile.FileName);
                    viewpatientrequestforme.UploadImage = viewpatientrequestforme.UploadFile.FileName;

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        viewpatientrequestforme.UploadFile.CopyTo(stream);
                    }

                    var requestwisefile = new Requestwisefile
                    {
                        Requestid = Request.Requestid,
                        Filename = viewpatientrequestforme.UploadImage,
                        Createddate = DateTime.Now,
                    };
                    _context.Requestwisefiles.Add(requestwisefile);
                    _context.SaveChanges();
                }
            }
            else
            {
                return View("../RequestByPatient/SubmitForSomeoneelse", viewpatientrequestforme);
            }
            return View();
        }
        #endregion
    }
}
