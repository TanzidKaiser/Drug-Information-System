using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Drug_Information_System.Models
{
    public class DoctorPrescription
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient Id")]
        public string PatientId { get; set; }

        [Required]
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [DisplayName("Patient Age")]
        public string PatientAge { get; set; }

        [Required]
        [DisplayName("Visited Date")]
        public string VisitedDate { get; set; }

        [DisplayName("Patient Email")]
        public string PatientEmail { get; set; }

        public string DoctorSuggestions { get; set; }

        public int? DoctorId { get; set; }
        public int? GenderId { get; set; }


        








        [ForeignKey("DoctorId")]
        public virtual User User { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }


        public virtual List<PrescribedDrugs> PrescribedDrugses { get; set; }
    }
}