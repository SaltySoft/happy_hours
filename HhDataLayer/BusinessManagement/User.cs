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
        public static List<T_User> GetListUser()
        {
            List<T_User> tmp = DataAccess.User.GetListUser();

            foreach (T_User item in tmp)
            {
                //TODO 
                //if (!item.T_Favorite.IsLoaded)
                //{
                //    item.T_Favorite.Load();
                //}
                //STUFF LIKE THAT
            }
            return tmp;
        }
    }
}
