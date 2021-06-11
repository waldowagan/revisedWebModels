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
        public string f_Name { get; set; }

    }
}
