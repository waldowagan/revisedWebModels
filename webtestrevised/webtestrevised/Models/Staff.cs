using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Staff : User
    {
        [DisplayName("Staff No.")]
        public string Staff_No { get; set; }

        public ICollection<CoursePaper> CoursePapers { get; set; }
    }
}
