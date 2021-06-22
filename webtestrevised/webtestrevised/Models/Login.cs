using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Login
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LoginID { get; set; }
        [DisplayName("Login Time")]
        public DateTime LoginTime { get; set; }
        [DisplayName("Name")]
        public string UserID { get; set; }
        [DisplayName("Name")]
        public User User { get; set; }
        // public string F_Name { get; set; }
        [DisplayName("With Client")]
        public bool Has_Client { get; set; }
        [DisplayName("With Course")]
        public bool Has_CoursePaper { get; set; }
        [DisplayName("Client")]
        public Client Client { get; set; }
        
        public string ClientID { get; set; }
        [DisplayName("Course")]
        public CoursePaper CoursePaper { get; set; }
        
        public string CoursePaperID { get; set; }
    }
}
