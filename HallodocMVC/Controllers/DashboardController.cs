using HallodocMVC.DataContext;
using HallodocMVC.DataModels;
using HallodocMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HallodocMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HalloDocContext _context;
        public DashboardController(HalloDocContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(CV.UserID()!=null)
            {
                var UserIDForRequest = _context.Users.Where(r => r.Aspnetuserid == CV.UserID()).FirstOrDefault();

                if (UserIDForRequest != null)
                {
                    List<DataModels.Request> Request = _context.Requests.Where(r => r.Userid == UserIDForRequest.Userid).ToList();
                    List<int> ids = new List<int>();

                    foreach (var request in Request)
                    {

                        var doc = _context.Requestwisefiles.Where(r => r.Requestid == request.Requestid).FirstOrDefault();
                        if (doc != null)
                        {
                            ids.Add(request.Requestid);
                        }
                    }
                    ViewBag.docidlist = ids;
                    ViewBag.listofrequest = Request;
                  
                }
                return View();
            }
            else
            {
                return View("../Home/Index");
            }

        }
        public IActionResult DocumentInfo(int? id)
        {

            List<Request> Request = _context.Requests.Where(r => r.Requestid == id).ToList();
            ViewBag.requestinfo = Request;
            List<Requestwisefile> DocList = _context.Requestwisefiles.Where(r => r.Requestid == id).ToList();
            ViewBag.DocList = DocList;
            return View("Documentsinfo");
        }

        public IActionResult UploadDoc(int Requestid, IFormFile? UploadFile)
        {
            string UploadImage;
            if (UploadFile != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fileNameWithPath = Path.Combine(path, UploadFile.FileName);
                UploadImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + UploadFile.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    UploadFile.CopyTo(stream)
;
                }
                var requestwisefile = new Requestwisefile
                {
                    Requestid = Requestid,
                    Filename = UploadFile.FileName,
                    Createddate = DateTime.Now,
                };
                _context.Requestwisefiles.Add(requestwisefile);
                _context.SaveChanges();
            }

            return RedirectToAction("Documentinfo", new { id = Requestid });
        }
    }
}
