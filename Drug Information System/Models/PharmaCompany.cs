using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Information_System.Models
{
  
    
    public  class PharmaCompany
    {
        
        public int Id { get; set; }
        public string PharmaName { get; set; }


        [NotMapped]
        public int? PharmaId { get; set; }
    
        public virtual List<DrugBrandInfo> DrugBrandInfoes { get; set; }
        public virtual List<UserActivity> UserActivities { get; set; }
    }
}
