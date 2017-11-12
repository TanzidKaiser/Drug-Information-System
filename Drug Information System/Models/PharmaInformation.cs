﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drug_Information_System.Models
{
    public class PharmaInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}