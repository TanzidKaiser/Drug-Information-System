using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Class;
using Drug_Information_System.Models;
using Drug_Information_System.Context;

namespace Drug_Information_System.Controllers
{
    public class CompanyController : Controller
    {
        private DrugInformationContext db = new DrugInformationContext();

        Activity activity = new Activity();
        DrugRecommendation drugRecommendation = new DrugRecommendation();
        DrugInformation drugInformation = new DrugInformation();

        // GET: /Company/
        public ActionResult Index()
        {
            var pharmaNames = db.PharmaCompanies.ToList();

            var topPharmaName =
                db.UserActivities.Where(c => c.PharmaId != null)
                    .GroupBy(d => new { d.PharmaId, d.PharmaCompany.PharmaName })
                    .Select(e => new { e.Key.PharmaId, e.Key.PharmaName, Count = e.Count() }).OrderByDescending(e => e.Count).Take(10).ToList();


            List<PharmaCompany> pharma = new List<PharmaCompany>();
            foreach (var item in topPharmaName)
            {
                PharmaCompany pharmaCompany = new PharmaCompany()
                {
                    PharmaName = item.PharmaName,
                    PharmaId = item.PharmaId
                };
                pharma.Add(pharmaCompany);
            }

            ViewBag.TopPharmaName = pharma;


            ViewBag.PharmaNames = pharmaNames.ToList();
            return View();
        }

        

        public ActionResult DrugInfo(int pharmaId)
        {
            activity.ClickActivityForPharma(pharmaId);


            
            var drugBrandInfos = db.DrugBrandInfos.Include(d => d.PharmaCompany);

            drugBrandInfos = db.DrugBrandInfos.Where(c => c.PharmaId == pharmaId);

            var pharmaCompanies = db.PharmaCompanies.Find(pharmaId);

            string pharmaName = pharmaCompanies.PharmaName;
            
            ViewBag.PharmaName = pharmaName;
            ViewBag.BrandInfos = drugBrandInfos.ToList();

            return View();
        }

        public ActionResult Details(int? id, int? genericId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = Session["user"] as User;
            var socialUser = Session["user"] as SocialUser;


            if (user != null)
            {
                int userId = user.Id;

                if (user.OccupationsId == 1)
                {
                    var rate = db.DrugsRatings.SingleOrDefault(c => c.UserId == userId && c.BrandId == id);

                    if (rate != null)
                    {
                        ViewBag.YourRating = rate.ProfessionalRatting;
                    }
                }
                else if (user.OccupationsId == 2)
                {
                    var rate = db.DrugsRatings.SingleOrDefault(c => c.UserId == userId && c.BrandId == id);

                    if (rate != null)
                    {
                        ViewBag.YourRating = rate.UserRatting;
                    }
                }

            }
            else if (socialUser != null)
            {
                int socialUserId = socialUser.Id;

                var rate = db.DrugsRatings.SingleOrDefault(c => c.SocialUserId == socialUserId && c.BrandId == id);

                if (rate != null)
                {
                    ViewBag.YourRating = rate.UserRatting;
                }
            }

            var userRating = db.DrugsRatings.Where(c => c.BrandId == id).Average(c => c.UserRatting);
            var professionalRating = db.DrugsRatings.Where(c => c.BrandId == id).Average(c => c.ProfessionalRatting);

            ViewBag.UserRating = userRating;
            ViewBag.ProfessionalRating = professionalRating;




            activity.ClickActivityForBrand(id);

            ViewBag.RelatedDrugs = drugRecommendation.DrugBrandInfosForGeneric(id, genericId);

            var arffPath = Path.Combine(Server.MapPath("~/Image"), "activityARFF.arff");
            var associatedDrugList = drugRecommendation.AssociateDrugs(id, arffPath);
            ViewBag.AssociatedDrugs = associatedDrugList;
            ViewBag.AssociatedDrugsCount = associatedDrugList.Count;


            var drugBrandInfo = db.DrugBrandInfos.Find(id);
            if (drugBrandInfo == null)
            {
                return HttpNotFound();
            }

            var genericInfo = db.DrugGenerics.Find(drugBrandInfo.GenericId);
            ViewBag.GenericInfo = genericInfo;

            var pregnancyInfo = db.PregnancyCategories.Find(genericInfo.PregnancyId);
            ViewBag.PregnancyInfo = pregnancyInfo;

            var pharmaName = db.PharmaCompanies.Find(drugBrandInfo.PharmaId);
            ViewBag.PharmaName = pharmaName.PharmaName;

            var therapiticNames = TherapiticNames(genericId);
            ViewBag.TherapiticNames = therapiticNames;

            var indicationNames = IndicationNames(genericId);
            ViewBag.IndicationNames = indicationNames;





            return View(drugBrandInfo);
        }

        [HttpPost]
        public ActionResult SaveRating(string rating, int drugId)
        {
            var user = Session["user"] as User;
            var socialUser = Session["user"] as SocialUser;

            string message = drugInformation.SetPersonalRating(rating, drugId, user, socialUser);

            if (message != "")
            {
                return Content("Rating Successfull");
            }
            else
            {
                return Content("Rating Not Successfull");
            }
        }

        [HttpPost]
        public ActionResult UserRating(int drugId)
        {
            double? userRating = drugInformation.UserRating(drugId);
            if (userRating == null)
            {
                return Content("0");
            }
            else
            {
                return Content(userRating.ToString());
            }
        }

        [HttpPost]
        public ActionResult ProfessionalRating(int drugId)
        {
            double? professionalRating = drugInformation.ProfessionalRating(drugId);
            if (professionalRating == null)
            {
                return Content("0");
            }
            else
            {
                return Content(professionalRating.ToString());
            }
        }



        private string IndicationNames(int? genericId)
        {

            var indicationGenericRelations = db.IndicationGenericRelations.Where(c => c.GenericId == genericId);

            string indicationNames = "";
            List<int?> idList = new List<int?>();

            foreach (var values in indicationGenericRelations)
            {
                idList.Add(values.IndicationId);
            }
            foreach (var value in idList)
            {

                if (!indicationNames.Equals(""))
                {
                    int? IndicationId = value;
                    var indications = db.Indications.Find(IndicationId);
                    indicationNames = indicationNames + ", " + indications.IndicationName;
                }
                else
                {
                    int? IndicationId = value;
                    var indications = db.Indications.Find(IndicationId);
                    indicationNames = indications.IndicationName;
                }
            }
            return indicationNames;
        }

        private string TherapiticNames(int? genericId)
        {

            var therapiticGenericRelations = db.TherapiticGenericRelations.Where(c => c.GenericId == genericId);
            
            string therapiticNames = "";

            List<int?> idList = new List<int?>();

            foreach (var values in therapiticGenericRelations)
            {
                idList.Add(values.TherapiticClassId);
            }
            foreach (var value in idList)
            {
                
                if (!therapiticNames.Equals(""))
                {
                    int? classId = value;
                    var therapiticClass = db.DrugTherapiticClasses.Find(classId);
                    therapiticNames = therapiticNames + ", " + therapiticClass.TherapiticClassName;
                }
                else
                {
                    int? classId = value;
                    var therapiticClass = db.DrugTherapiticClasses.Find(classId);
                    therapiticNames = therapiticClass.TherapiticClassName;
                }
            }
            return therapiticNames;
        }
    }
}
