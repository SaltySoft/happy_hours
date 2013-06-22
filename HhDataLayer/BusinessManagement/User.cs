using HhDataLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhDataLayer.BusinessManagement
{
    public class User
    {
        /// <summary>
        /// retourne la liste complete de tous les utilisateurs.
        /// </summary>
        /// <returns>la liste des utilisateurs sinon une liste vide</returns>
        public static List<DBO.User> GetListUser(int max)
        {
            return DataAccess.User.GetListUser(max);
        }
    }
}
