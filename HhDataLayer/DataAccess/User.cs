using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhDataLayer.DataAccess
{
    public class User
    {
        /// <summary>
        /// retourne la liste complete de tous les utilisateurs.
        /// </summary>
        /// <returns>la liste des utilisateurs sinon une liste vide</returns>
        public static List<T_User> GetListUser()
        {
            try
            {
                //HappyHoursEntities model = new HappyHoursEntities();
                //List<T_User> users = model.T_User.ToList();
                //return users;
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_User> existings = bdd.T_User.ToList();
                    return existings;
                }
            }
            catch (Exception ex)
            {
                return new List<T_User>();
            }
        }
    }
}
