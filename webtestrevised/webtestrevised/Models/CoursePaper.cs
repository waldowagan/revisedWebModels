using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class CoursePaper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CoursePaperID { get; set; }
        [DisplayName("Course No.")]
        public string CoursePaper_No { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public string StaffID { get; set; }
        [DisplayName("Staff Name")]
        public Staff Staff { get; set; }
        public string User_Type { get; set; }
    }
}
