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
            try
            {
                List<HhDBO.User> users = HhBusiness.User.GetListUser(max).ToList();
                return users;
            }
            catch (Exception)
            {
                return new List<HhDBO.User>();
            }
        }

        public List<HhDBO.User> GetUser(int id)
        {
            try
            {
                List<HhDBO.User> users = HhBusiness.User.GetUser(id).ToList();
                return users;
            }
            catch (Exception)
            {
                return new List<HhDBO.User>();
            }
        }

        public HhDBO.User GetUserByName(string name)
        {
            try
            {
                HhDBO.User user = HhBusiness.User.GetUserByName(name);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HhDBO.User CreateUser(HhDBO.User user)
        {
            try
            {
                return HhBusiness.User.CreateUser(user);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateUser(HhDBO.User user)
        {
            try
            {
                return HhBusiness.User.UpdateUser(user);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                return HhBusiness.User.DeleteUser(id);
            }
            catch (Exception)
            {
                return false;
            }
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