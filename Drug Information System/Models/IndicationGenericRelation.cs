using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Information_System.Models
{
    
    
    public  class IndicationGenericRelation
    {
        public int Id { get; set; }
        public int? GenericId { get; set; }
        public int? IndicationId { get; set; }


        [ForeignKey("GenericId")]
        public virtual DrugGeneric DrugGeneric { get; set; }

        [ForeignKey("IndicationId")]
        public virtual Indication Indication { get; set; }
    }
}
