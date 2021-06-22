using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Student : User
    {
        [DisplayName("Student No.")]
        public string Student_No { get; set; }
        [DisplayName("Membership Start")]
        public DateTime Membership_Start { get; set; }
        [DisplayName("Memership End")]
        public DateTime Membership_End { get; set; }
        public bool Payment { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
