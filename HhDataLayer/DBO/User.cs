using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhDataLayer.DBO
{
    public class User
    {
        #region variables
        private string _username;
        private string _email;
        private string _password;
        private int _admin;
        #endregion

        #region getter / setter
        /// <summary>
        /// username
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// admin : either 1 or 0
        /// </summary>
        public int Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        #endregion
    }
}
