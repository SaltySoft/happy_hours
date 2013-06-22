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

        public List<ServiceReferenceHappyHours.T_User> GetListUser(int max)
        {
            try
            {
                ServiceReferenceHappyHours.ServiceClientHappyHoursClient client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
                List<ServiceReferenceHappyHours.T_User> users2 = client.GetListUser(max).ToList();

                List<ServiceReferenceHappyHours.T_User> users = _client.GetListUser(max).ToList();
                return users;
            }
            catch (Exception ex)
            {
                return new List<ServiceReferenceHappyHours.T_User>();
            }
        }
    }
}