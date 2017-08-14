using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrakCare.Web.Common
{
    public class TrakCareQuery
    {
        public static Tuple<string, Dictionary<string,string>> GetUser(string userInitials)
        {
            string s = @"
                SELECT SSUSR_Initials, SSUSR_Name, SSUSR_Password 
                FROM SS_USER WHERE SSUSR_Initials = ?
            ";
            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SSUSR_Initials", userInitials);


            return new Tuple<string, Dictionary<string, string>>(s, dic);
        }
    }
}
