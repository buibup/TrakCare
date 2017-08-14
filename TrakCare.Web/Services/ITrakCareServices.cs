using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakCare.Web.Models;

namespace TrakCare.API.Services
{
    public interface ITrakCareServices
    {
        Tuple<User, string> TrakCareUserAuthen(User user);
    }
}
