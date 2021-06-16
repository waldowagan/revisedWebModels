using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class CoursePaper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CoursePaperID { get; set; }
        public string CoursePaper_No { get; set; }
        public string CourseName { get; set; }
        public string StaffID { get; set; }
        public Staff Staff { get; set; }
        public string User_Type { get; set; }
    }
}
