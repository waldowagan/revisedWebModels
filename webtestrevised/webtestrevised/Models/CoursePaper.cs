using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class CoursePaper
    {
          public string CoursePaperID { get; set; }
        public string CourseName { get; set; }
        public string StaffID { get; set; }
        public Staff Staff { get; set; }
    }
}
