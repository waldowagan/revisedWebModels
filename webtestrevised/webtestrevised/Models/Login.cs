using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webtestrevised.Models
{
    public class Login
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LoginID { get; set; }
        public DateTime LoginTime { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        // public string F_Name { get; set; }
        public bool Has_Client { get; set; }
        public bool Has_CoursePaper { get; set; }
        public Client Client { get; set; }
        public string ClientID { get; set; }
        public CoursePaper CoursePaper { get; set; }
        public string CoursePaperID { get; set; }
    }
}
