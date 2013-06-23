using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhBusiness
{
    public class User
    {
        /// <summary>
        /// retourne la liste complete de tous les utilisateurs.
        /// </summary>
        /// <returns>la liste des utilisateurs sinon une liste vide</returns>
        public static List<HhDBO.User> GetListUser(int max)
        {
            return HhDataLayer.DataAccess.User.GetListUser(max);
        }

        /// <summary>
        /// retourne une liste contenant un utilisateur
        /// </summary>
        /// <returns>la liste contenant l'utilisateur correspondant à l'id sinon une liste vide</returns>
        public static List<HhDBO.User> GetUser(int id)
        {
            return HhDataLayer.DataAccess.User.GetUser(id);
        }
    }
}
