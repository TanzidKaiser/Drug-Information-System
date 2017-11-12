using System;
using System.Collections.Generic;

namespace Drug_Information_System.Models
{
  
    
    public  class PregnancyCategory
    {
       
        public int Id { get; set; }
        public string PregnancyName { get; set; }
        public string PregnancyDiscription { get; set; }
    
        public virtual List<DrugGeneric> DrugGenerics { get; set; }
    }
}
