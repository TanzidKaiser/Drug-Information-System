using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class BaseModel
    {
        [NotMapped]
        [Required]
        public string SearchKeyWord { get; set; }

        [Required]
        [NotMapped]
        public string SearchItemValue { get; set; }
    }
}