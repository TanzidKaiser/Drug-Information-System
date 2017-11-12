using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Drug_Information_System.Models
{
    
    
    public class DrugBrandInfo : BaseModel
    {
       
    
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string DrugForm { get; set; }
        public string DrugStrength { get; set; }
        public string OTCStatus { get; set; }
        public string PillID { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
        public string PackSize { get; set; }
        public float? Price { get; set; }

        public int? GenericId { get; set; }
        public int? PharmaId { get; set; }
        public int? DrugStatusId { get; set; }

        [NotMapped]
        public string Rating { get; set; }
        [NotMapped]
        public int? BrandId { get; set; }

        


        [ForeignKey("GenericId")]
        public virtual DrugGeneric DrugGeneric { get; set; }

        [ForeignKey("DrugStatusId")]
        public virtual DrugStatus DrugStatus { get; set; }

        [ForeignKey("PharmaId")]
        public virtual PharmaCompany PharmaCompany { get; set; }

        public virtual List<DrugsRating> DrugsRatings { get; set; }
        public virtual List<UserActivity> UserActivities { get; set; }
    }
}
