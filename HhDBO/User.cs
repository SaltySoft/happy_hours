using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HhDBO
{
    [DataContract]
    public class User
    {
        #region variables
        private int _id;
        private string _username;
        private string _email;
        private string _password;
        private int _admin;
        private List<string> _roles;
        #endregion

        #region getter / setter
        /// <summary>
        /// id
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// username
        /// </summary>
        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// email
        /// </summary>
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// password
        /// </summary>
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// admin : either 1 or 0
        /// </summary>
        [DataMember]
        public int Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public List<String> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        #endregion
    }
}
