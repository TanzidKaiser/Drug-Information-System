using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Models;
using Drug_Information_System.Context;

namespace Drug_Information_System.Controllers
{
    public class AdminController : Controller
    {
        private DrugInformationContext db = new DrugInformationContext();

        // GET: /Default1/
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user != null && user.UserRole.Equals("admin"))
            {
                var users = db.Users.Include(u => u.Gender).Include(u => u.Occupation).Include(u => u.Profession).Where(c => c.OccupationsId == 1 && c.ProfessionId == 3);
                ViewBag.UnApproveUsers = users.ToList();
                return View();
            }
            return null;
        }

        [HttpPost]
        public ActionResult UpdateUserApproval(int userId, bool value)
        {
            var check = db.Users.Any(c => c.Id == userId && c.UserApproval != value);

            if (check)
            {
                var Users = db.Users.Find(userId);
                Users.UserApproval = value;

                var rowAffected = db.SaveChanges();
                if (rowAffected > 0)
                {
                    return Content("Update Complete");
                }
                else
                {
                    return Content("Update Not Complete");
                }
            }

            return Content("Nothing To Update");

        }

        public ActionResult DownloadIdentity(string userName)
        {
            var user = Session["User"] as User;

            if (user != null && user.UserRole.Equals("admin"))
            {
                string path = Server.MapPath("~/App_Data/DoctorIdentity/");
                var files = Directory.GetFiles(path, userName + ".*");
                var getpath = new DirectoryInfo(files[0]);
                var getEXT = getpath.Extension;

                var data = File(files[0], System.Net.Mime.MediaTypeNames.Application.Octet, userName + getEXT);
                return data;
            }


            return null;

            

        }


        
    }
}
