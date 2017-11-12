

using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Information_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public  class Indication
    {
       
    
        public int Id { get; set; }
        public string IndicationName { get; set; }

        [NotMapped]
        public int? IndicationId { get; set; }

        public virtual List<IndicationGenericRelation> IndicationGenericRelations { get; set; }
        public virtual List<UserActivity> UserActivities { get; set; }
    }
}
