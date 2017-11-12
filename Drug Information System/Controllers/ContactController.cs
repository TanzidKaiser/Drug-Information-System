using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Models;
using Drug_Information_System.Context;

namespace Drug_Information_System.Controllers
{
    public class ContactController : Controller
    {
        private DrugInformationContext db = new DrugInformationContext();

        

        
        public ActionResult Create()
        {
            ViewBag.message = " ";
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Subject,Name,Email,Message")] MessageInfo messageinfo)
        {
            db.MessageInfos.Add(messageinfo);
            var rowAffected = db.SaveChanges();

            if (rowAffected > 0)
            {
                ViewBag.message = "Send Message Successfully";
            }
            else
            {
                ViewBag.message = "Send Message Failed";
            }
                

            return View();
        }

       

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
