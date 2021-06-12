using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Student : User
    {
        public string student_No { get; set; }
        public DateTime membership_Start { get; set; }
        public DateTime membership_End { get; set; }
        public bool payment { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
