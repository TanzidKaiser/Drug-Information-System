using System;
using System.Collections.Generic;

namespace Drug_Information_System.Models
{
   
    
    public  class DrugSystemicClass
    {
        
    
        public int Id { get; set; }
        public string SystemicClassName { get; set; }
        public int ParentClassId { get; set; }
    
        public virtual List<DrugTherapiticClass> DrugTherapiticClasses { get; set; }
    }
}
