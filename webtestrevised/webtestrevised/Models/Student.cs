using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Student : User
    {
        public string Student_No { get; set; }
        public DateTime Membership_Start { get; set; }
        public DateTime Membership_End { get; set; }
        public bool Payment { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
