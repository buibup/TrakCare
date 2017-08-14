using InterSystems.Data.CacheClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakCare.Web.Common;
using TrakCare.Web.Models;

namespace TrakCare.Web.DAL
{
    public class Cache
    {
        public static Tuple<User, string> GetUser(string username, string password)
        {
            var model = new User();
            string message = string.Empty;

            var query = TrakCareQuery.GetUser(username);

            using (CacheConnection con = new CacheConnection(Constants.Cache))
            {
                con.Open();
                using (CacheCommand cmd = new CacheCommand(query.Item1, con))
                {
                    foreach(KeyValuePair<string,string> pair in query.Item2)
                    {
                        var key = pair.Key;
                        cmd.AddInputParameters(new { key = pair.Value });
                    }
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User()
                            {
                                SSUSR_Initials = reader["SSUSR_Initials"].ToString(),
                                SSUSR_Name = reader["SSUSR_Name"].ToString(),
                                SSUSR_Password = reader["SSUSR_Password"].ToString()
                            };

                            if (Helper.CheckPassword(user, password))
                            {
                                model = user;
                                message = "Login Success.";
                            }
                            else
                            {
                                message = "Login fail.";
                            }
                        }
                    }
                }
            }

            return new Tuple<User, string>(model, message);
        }
    }
}
