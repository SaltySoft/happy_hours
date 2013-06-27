using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HhBackend.BusinessManagement
{
    public class User
    {
        public static bool ValidateUser(string username, string password)
        {
            return DataAccess.User.ValidateUser(username, password);
        }

        public static HhDBO.User GetUser(string username)
        {
            return DataAccess.User.GetUser(username);
        }
    }

}