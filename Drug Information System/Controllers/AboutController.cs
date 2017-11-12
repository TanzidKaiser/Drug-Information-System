using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drug_Information_System.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
	}
}