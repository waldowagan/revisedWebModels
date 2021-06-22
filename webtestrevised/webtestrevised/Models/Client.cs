using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ClientID { get; set; }
        [DisplayName("First Name")]
        public string F_Name { get; set; }
        [DisplayName("Last Name")]
        public string L_Name { get; set; }
        public string Email { get; set; }
        [DisplayName("Contact No.")]
        public string Phone_No { get; set; }
        [DisplayName("Emergency Contact")]
        public string Emergency_Contact_Name { get; set; }
        [DisplayName("Emergency Contact #")]
        public string Emergency_Contact_No { get; set; }

      //  public DateTime Login_Time { get; set; }

        public string User_Type { get; set; }

        public string StudentID { get; set; }
        [DisplayName("Student Name")]
        public Student Student { get; set; }
        [DisplayName("Name")]
        public string FullName { get { return F_Name + " " + L_Name; } }
    }
}
