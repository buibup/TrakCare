using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakCare.Web.DAL;
using TrakCare.Web.Models;

namespace TrakCare.API.Services
{
    public class TrakCareServices : ITrakCareServices
    {
        public Tuple<User,string> TrakCareUserAuthen(User user)
        {
            return Cache.GetUser(user.SSUSR_Initials, user.SSUSR_Password);
        }
    }
}
