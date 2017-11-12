using System;
using System.Collections.Generic;

namespace Drug_Information_System.Models
{
 
    
    public  class Gender
    {
       
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual List<User> Users { get; set; }
        public virtual List<DoctorPrescription> DoctorPrescriptions { get; set; }
    }
}
