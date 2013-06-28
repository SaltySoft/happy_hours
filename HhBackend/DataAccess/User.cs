﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace HhBackend.DataAccess
{
    public class User
    {
        public static bool ValidateUser(string username, string password)
        {
            bool response = false;
            using (HappyHoursEntities ctx = new HappyHoursEntities())
            {
                byte[] data = BusinessManagement.User.GetBytesFromString(password);

                byte[] result;

                using (SHA256 shaM = new SHA256Managed())
                {
                    result = shaM.ComputeHash(data);
                }
                password = BusinessManagement.User.GetStringFromBytes(result);

                response = ctx.T_User.Where(x => x.username == username && x.password == password).ToList().Any();
            }
            return response;
        }

        public static HhDBO.User GetUser(string username)
        {
            HhDBO.User user = null;

            using (HappyHoursEntities ctx = new HappyHoursEntities())
            {
                Mapper.CreateMap<T_User, HhDBO.User>();
                T_User t = ctx.T_User.Where(x => x.username == username).FirstOrDefault();
                if (t != null)
                    user = Mapper.Map<T_User, HhDBO.User>(t);
            }

            return user;
        }
    }
}