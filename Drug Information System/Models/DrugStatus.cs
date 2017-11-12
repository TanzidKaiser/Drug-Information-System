using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class DrugStatus
    {
        public int Id { get; set; }
        public string Availability { get; set; }

        [DisplayName("CSA Schedule")]
        public string CSASchedule { get; set; }

        [DisplayName("Approval History")]
        public string ApprovalHistory { get; set; }


        public virtual List<DrugBrandInfo> DrugBrandInfos { get; set; }
    }
}