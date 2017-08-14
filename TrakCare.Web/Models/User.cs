using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrakCare.Web.Models
{
    public class User
    {
        public string SSUSR_Initials { get; set; }
        public string SSUSR_Name { get; set; }
        public string SSUSR_Password { get; set; }
    }
}
