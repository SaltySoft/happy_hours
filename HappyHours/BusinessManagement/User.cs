using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class User
    {
        public static List<ServiceReferenceHappyHours.T_User> GetListUser(int max)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.GetListUser(max);
        }
    }
}