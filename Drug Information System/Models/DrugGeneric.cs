using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Drug_Information_System.Models
{
   
    public class DrugGeneric
    {
       
        public int Id { get; set; }
        public string GenericName { get; set; }
        public string WarningAndPrecaution { get; set; }
        public string Contraindication { get; set; }
        public string DosageForm { get; set; }
        public string SideEffect { get; set; }
        public string ModeOfAction { get; set; }
        public string Interaction { get; set; }

        
        public int? PregnancyId { get; set; }

        [NotMapped]
        public int? GenericId { get; set; }

        [ForeignKey("PregnancyId")]
        public virtual PregnancyCategory PregnancyCategory { get; set; }
    
        public virtual List<DrugBrandInfo> DrugBrandInfoes { get; set; }
        
        public virtual List<IndicationGenericRelation> IndicationGenericRelations { get; set; }
        public virtual List<TherapiticGenericRelation> TherapiticGenericRelations { get; set; }
        public virtual List<UserActivity> UserActivities { get; set; }
    }
}
