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

        public static byte[] GetBytesFromString(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }

}