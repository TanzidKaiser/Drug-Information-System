using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;
using Drug_Information_System.Models;
using Drug_Information_System.Context;

namespace Drug_Information_System.Controllers
{
    public class SearchController : Controller
    {
        private DrugInformationContext db = new DrugInformationContext();

        Activity activity = new Activity();
        DrugRecommendation drugRecommendation = new DrugRecommendation();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AllBrandNames(string prefix)
        {
            DrugInformationContext db = new DrugInformationContext();

            var drugsName = (from names in db.DrugBrandInfos
                             where names.BrandName.StartsWith(prefix)
                             select new
                             {
                                 id = names.Id,
                                 brandName = names.BrandName,
                                 drugForm = names.DrugForm,
                                 drugStrength = names.DrugStrength,
                                 genericId = names.GenericId
                                 
                             }).Take(20).ToList();
            return Json(drugsName);
        }

        [HttpPost]
        public JsonResult AllGenericNames(string prefix)
        {
            DrugInformationContext db = new DrugInformationContext();

            var genericNames = (from names in db.DrugGenerics
                             where names.GenericName.StartsWith(prefix)
                             select new
                             {
                                 id = names.Id,
                                 genericName = names.GenericName

                             }).Take(15).ToList();
            return Json(genericNames);
        }

        [HttpPost]
        public JsonResult AllIndicationNames(string prefix)
        {
            DrugInformationContext db = new DrugInformationContext();

            var indicationNames = (from names in db.Indications
                                where names.IndicationName.Contains(prefix)
                                select new
                                {
                                    id = names.Id,
                                    indicationName = names.IndicationName

                                }).Take(30).ToList();
            return Json(indicationNames);
        }


        [HttpPost]
        public JsonResult AllCompanyNames(string prefix)
        {
            DrugInformationContext db = new DrugInformationContext();

            var pharmaNames = (from names in db.PharmaCompanies
                                   where names.PharmaName.Contains(prefix)
                                   select new
                                   {
                                       id = names.Id,
                                       pharmaNames = names.PharmaName

                                   }).Take(30).ToList();
            return Json(pharmaNames);
        }


        

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
