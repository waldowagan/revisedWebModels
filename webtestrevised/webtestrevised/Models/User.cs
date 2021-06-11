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
        public string f_Name { get; set; }
        public string l_Name { get; set; }
        public string email { get; set; }
        public string phone_No { get; set; }
        public string emergency_Contact_Name { get; set; }
        public string emergency_Contact_No { get; set; }

        public DateTime login_Time { get; set; }

        public string user_Type { get; set; }

    }
}
