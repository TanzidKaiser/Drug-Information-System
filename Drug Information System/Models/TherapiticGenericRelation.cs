using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Drug_Information_System.Models
{
 
    public  class TherapiticGenericRelation
    {
        public int Id { get; set; }
        public int? GenericId { get; set; }
        public int? TherapiticClassId { get; set; }

        [ForeignKey("GenericId")]
        public virtual DrugGeneric DrugGeneric { get; set; }

        [ForeignKey("TherapiticClassId")]
        public virtual DrugTherapiticClass DrugTherapiticClass { get; set; }
    }
}
