using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Context;

namespace Drug_Information_System.Controllers
{
    public class ManifoldController : Controller
    {
        DrugInformationContext db = new DrugInformationContext();
        
        public ActionResult CompaniesInformation()
        {
            
            var pharmaInfo = db.PharmaInformations.ToList();
            ViewBag.PharmaInfo = pharmaInfo;

            return View();
        }

        
        public ActionResult HospitalsAndClinicsInfo()
        {
            var hospitalInfo = db.HospitalsAndClinicses.ToList();
            ViewBag.HospitalInfo = hospitalInfo;
            return View();
        }
	}
}