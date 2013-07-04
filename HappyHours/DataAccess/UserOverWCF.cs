using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class UserOverWCF
    {
        private ServiceReferenceHappyHours.ServiceClientHappyHoursClient _client;

        public ServiceReferenceHappyHours.ServiceClientHappyHoursClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public UserOverWCF()
        {
            _client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
        }

        public List<HhDBO.User> GetListUser(int max)
        {
            try
            {
                List<HhDBO.User> users = _client.GetListUser(max).ToList();
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
                List<HhDBO.User> users = _client.GetUser(id).ToList();
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
                HhDBO.User user = _client.GetUserByName(name);
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
                return _client.CreateUser(user);
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
                return _client.UpdateUser(user);
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
                return _client.DeleteUser(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}