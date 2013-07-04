using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class User
    {
        public List<HhDBO.User> GetListUser(int max)
        {
            List<HhDBO.User> users = HhBusiness.User.GetListUser(max).ToList();
            return users;
        }

        public List<HhDBO.User> GetUser(int id)
        {
            List<HhDBO.User> users = HhBusiness.User.GetUser(id).ToList();
            return users;
        }

        public HhDBO.User GetUserByName(string name)
        {
            HhDBO.User user = HhBusiness.User.GetUserByName(name);
            return user;
        }

        public HhDBO.User CreateUser(HhDBO.User user)
        {
            return HhBusiness.User.CreateUser(user);
        }

        public bool UpdateUser(HhDBO.User user)
        {
            return HhBusiness.User.UpdateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return HhBusiness.User.DeleteUser(id);
        }

        public List<string> Validate(HhDBO.User user)
        {
            return HhBusiness.User.Validate(user);
        }

        public static byte[] GetBytesFromString(string str)
        {
            return HhBusiness.User.GetBytesFromString(str);
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            return HhBusiness.User.GetStringFromBytes(bytes);
        }
    }
}