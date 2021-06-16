using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Staff : User
    {
        public string Staff_No { get; set; }

        public ICollection<CoursePaper> CoursePapers { get; set; }
    }
}
