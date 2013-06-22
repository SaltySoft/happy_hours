using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class User
    {
        public static List<HhDataLayer.DBO.User> GetListUser(int max)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.GetListUser(max);
        }

        public static String Test()
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.Test();
        }
    }
}