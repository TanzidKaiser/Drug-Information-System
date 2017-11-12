using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class SocialUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
        public string SocialSiteName { get; set; }

        public virtual List<UserActivity> UserActivities { get; set; }

        public virtual List<DrugsRating> DrugsRatings { get; set; }
    }
}