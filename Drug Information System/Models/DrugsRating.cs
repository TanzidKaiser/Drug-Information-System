using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class DrugsRating
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int? UserId { get; set; }
        public int? SocialUserId { get; set; }
        public int? UserRatting { get; set; }
        public int? ProfessionalRatting { get; set; }



        [ForeignKey("BrandId")]
        public virtual DrugBrandInfo DrugBrandInfo { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("SocialUserId")]
        public virtual SocialUser SocialUser { get; set; }
    }
}