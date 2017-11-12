

using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Information_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public class DrugTherapiticClass
    {
      
    
        public int Id { get; set; }
        public string TherapiticClassName { get; set; }
        public int? SystemicClassId { get; set; }

        [ForeignKey("SystemicClassId")]
        public virtual DrugSystemicClass DrugSystemicClass { get; set; }


        public virtual List<TherapiticGenericRelation> TherapiticGenericRelations { get; set; }
        public virtual List<UserActivity> UserActivities { get; set; }
    }
}
