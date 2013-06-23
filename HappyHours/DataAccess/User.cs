using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class User
    {
        private ServiceReferenceHappyHours.ServiceClientHappyHoursClient _client;

        public ServiceReferenceHappyHours.ServiceClientHappyHoursClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public User()
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return new List<HhDBO.User>();
            }
        }

        public String Test()
        {
            ServiceReferenceHappyHours.ServiceClientHappyHoursClient client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
            String str = client.Test();
            return str;
        }
    }
}