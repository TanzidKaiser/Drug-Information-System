using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drug_Information_System.Context;
using Drug_Information_System.Models;
using Rotativa;

namespace Drug_Information_System.Controllers
{
    public class PrescriptionController : Controller
    {
       private DrugInformationContext db = new DrugInformationContext();
        public ActionResult Index()
        {
            var user = Session["User"] as User;
            if (user != null && user.OccupationsId == 1 && user.ProfessionId == 3)
            {
                ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
                ViewBag.message = "";
                return View();
            }
            
            return null;
        }

        [HttpPost]
        public ActionResult Index(DoctorPrescription doctorPrescription )
        {
            var user = Session["User"] as User;
            var rowId = db.DoctorPrescriptions.Count();
            
            if (user != null && user.OccupationsId == 1 && user.ProfessionId == 3)
            {
                string patientName = doctorPrescription.PatientName;
                string patientAge = doctorPrescription.PatientAge;
                string visitedDate = DateTime.Today.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                int? genderId = doctorPrescription.GenderId;
                int doctorId = user.Id;

                char[] charsToTrim = { '/', ' ', '-'};
                string patientId = (rowId + 1) + "11" + (rowId + 1);


                 DoctorPrescription prescription = new DoctorPrescription()
                {
                    PatientId = patientId,
                    PatientName = patientName,
                    PatientAge = patientAge,
                    VisitedDate = visitedDate,
                    DoctorId = doctorId,
                    GenderId = genderId
                };
                db.DoctorPrescriptions.Add(prescription);
                var rowAffected = db.SaveChanges();

                if (rowAffected > 0)
                {
                    var id = db.DoctorPrescriptions.SingleOrDefault(c => c.PatientId == patientId);
                    int prescriptionId = id.Id;
                    return RedirectToAction("AddDrugs", new {prescriptionId = prescriptionId});
                }
                else
                {
                    ViewBag.message = "Information Not Save . Please try again !!";
                    return View();
                }

            }
            
            return null;
        }

        public ActionResult AddDrugs(int prescriptionId)
        {
            var prescribe = db.DoctorPrescriptions.Find(prescriptionId);
            var user = db.Users.Find(prescribe.DoctorId);

            string gender = "";
            if (prescribe.GenderId == 1)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            var prescrivedDrugs = db.PrescribedDrugses.Where(c => c.DoctorPrescriptionId == prescriptionId).ToList();

            ViewBag.PrescrivedDrugs = prescrivedDrugs;

            ViewBag.PrescriptionId = prescriptionId;
            ViewBag.PatientName = prescribe.PatientName;
            ViewBag.PatientAge = prescribe.PatientAge;
            ViewBag.Gender = gender;
            ViewBag.VisitedDate = prescribe.VisitedDate;
            ViewBag.PatientId = prescribe.PatientId;
            ViewBag.Suggestion = prescribe.DoctorSuggestions;

            ViewBag.DoctorName = user.FirstName + " " + user.LastName;
            ViewBag.Address = user.Address;
            ViewBag.Email = user.Email;
            
            return View();
        }


        [HttpPost]
        public ActionResult SaveDrugs(string drugName, string dosageForm, string dosageDudation, string extraNote, int? doctorPrescriptionId)
        {
            var check = db.PrescribedDrugses.Any( c => c.DoctorPrescriptionId == doctorPrescriptionId && c.DrugName.Contains(drugName));

            if (!check)
            {
                PrescribedDrugs prescribedDrugs = new PrescribedDrugs()
                {
                    DrugName = drugName,
                    DosageForm = dosageForm,
                    DosageDuration = dosageDudation,
                    ExtraNote = extraNote,
                    DoctorPrescriptionId = doctorPrescriptionId

                };
                db.PrescribedDrugses.Add(prescribedDrugs);
                var rowAffected = db.SaveChanges();
                if (rowAffected > 0)
                {
                    var id =
                        db.PrescribedDrugses.SingleOrDefault(
                            c => c.DrugName == drugName && c.DoctorPrescriptionId == doctorPrescriptionId);
                    int prescribedDrugId = id.Id;
                    return Content(prescribedDrugId.ToString());
                }
            }
            else
            {
                return Content("Drug is already added in the list");
            }
            
            return null;
        }


        [HttpPost]
        public ActionResult DeleteDrugs(string drugId)
        {
            int id = Convert.ToInt32(drugId);

            var itemToRemove = db.PrescribedDrugses.Find(id);

            if (itemToRemove != null)
            {
                db.PrescribedDrugses.Remove(itemToRemove);
                db.SaveChanges();
                return Content("Delete SuccessFull");

            }

            return null;
        }

        [HttpPost]
        public ActionResult AddSuggestion(string prescriptionId, string content)
        {
            var prescriptionRow = db.DoctorPrescriptions.Find(Convert.ToInt32(prescriptionId));

            if (prescriptionRow != null)
            {
                prescriptionRow.DoctorSuggestions = content;
                db.Entry(prescriptionRow).State = EntityState.Modified;
                var rowAffected = db.SaveChanges();
                if (rowAffected > 0)
                {
                    return Content("Update SuccessFull");
                }
            }

            return null;
        }


        public ActionResult PDF(string prescriptionId)
        {
            int id = Convert.ToInt32(prescriptionId);
            var prescription = db.DoctorPrescriptions.Find(id);
            var drugs = db.PrescribedDrugses.Where(c => c.DoctorPrescriptionId == id).ToList();

            var users = db.Users.Find(prescription.DoctorId);
            string doctorName = users.FirstName + " " + users.LastName;
            string address = users.Address;
            string email = users.Email;

            string patientName = prescription.PatientName;
            string patientAge = prescription.PatientAge;
            string patientGender = "";
            if (prescription.GenderId == 1)
            {
                patientGender = "Male";
            }
            else
            {
                patientGender = "Female";
            }
            string visitedDate = prescription.VisitedDate;
            string patientId = prescription.PatientId;

            string doctorSuggestions = prescription.DoctorSuggestions;


            ViewBag.DoctorName = doctorName;
            ViewBag.Address = address;
            ViewBag.Email = email;

            ViewBag.PatientName = patientName;
            ViewBag.PatientAge = patientAge;
            ViewBag.PatientGender = patientGender;
            ViewBag.VisitedDate = visitedDate;
            ViewBag.PatientId = patientId;

            ViewBag.DoctorSuggestion = doctorSuggestions;

            ViewBag.Drugs = drugs;

            //Install-Package Rotativa then call new ViewAsPDF("actionName")
            return new ViewAsPdf("PDF");
        }


        public ActionResult AllPrescription()
        {
            var user = Session["User"] as User;

            if (user != null && user.OccupationsId == 1 && user.ProfessionId == 3)
            {
                var doctorPrescription = db.DoctorPrescriptions.Where(c => c.DoctorId == user.Id).ToList();
                ViewBag.doctorPrescription = doctorPrescription;
                return View();
            }

            return null;
        }


        [HttpPost]
        public JsonResult AllBrandNames(string prefix)
        {
            DrugInformationContext db = new DrugInformationContext();

            var drugsName = (from names in db.DrugBrandInfos
                             where names.BrandName.StartsWith(prefix)
                             select new
                             {
                                 brandName = names.BrandName,
                                 drugForm = names.DrugForm,
                                 drugStrength = names.DrugStrength
                             }).Take(10).ToList();
            return Json(drugsName);
        }

	}
}