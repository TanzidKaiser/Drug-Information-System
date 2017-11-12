

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drug_Information_System.Models
{
   
    public class UserActivity
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public DateTime ActivityTime { get; set; }


        public int? BrandId { get; set; }
        public int? GenericId { get; set; }
        public int? TherapiticClassId { get; set; }
        public int? PharmaId { get; set; }
        public int? IndicationId { get; set; }
        public int? UserId { get; set; }
        public int? SocialUserId { get; set; }


        [ForeignKey("BrandId")]
        public virtual DrugBrandInfo DrugBrandInfo { get; set; }

        [ForeignKey("GenericId")]
        public virtual DrugGeneric DrugGeneric { get; set; }

        [ForeignKey("TherapiticClassId")]
        public virtual DrugTherapiticClass DrugTherapiticClass { get; set; }

        [ForeignKey("IndicationId")]
        public virtual Indication Indication { get; set; }

        [ForeignKey("PharmaId")]
        public virtual PharmaCompany PharmaCompany { get; set; }

        [ForeignKey("SocialUserId")]
        public virtual SocialUser SocialUser { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
       
    }
}
