using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class User
    {
        public static List<HhDBO.User> GetListUser(int max)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.GetListUser(max);
        }

        public static List<HhDBO.User> GetUser(int id)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.GetUser(id);
        }

        public static HhDBO.User GetUserByName(string name)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.GetUserByName(name);
        }

        public static HhDBO.User CreateUser(HhDBO.User user)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.CreateUser(user);
        }

        public static bool UpdateUser(HhDBO.User user)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.UpdateUser(user);
        }

        public static bool DeleteUser(int id)
        {
            DataAccess.User dataAccess = new DataAccess.User();
            return dataAccess.DeleteUser(id);
        }
    }
}