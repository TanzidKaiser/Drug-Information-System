using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class PrescribedDrugs
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public string DosageForm { get; set; }
        public string DosageDuration { get; set; }
        public string ExtraNote { get; set; }

        public int? DoctorPrescriptionId { get; set; }



        [ForeignKey("DoctorPrescriptionId")]
        public virtual DoctorPrescription DoctorPrescription { get; set; }
    }
}