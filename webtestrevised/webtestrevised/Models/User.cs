using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserID { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Emergency_Contact_Name { get; set; }
        public string Emergency_Contact_No { get; set; }

       // public DateTime Login_Time { get; set; }

        public string User_Type { get; set; }

        public string FullName { get { return F_Name + " " + L_Name; } }

    }
}
