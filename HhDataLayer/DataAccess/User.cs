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
        public static List<DBO.User> GetListUser(int max)
        {
            try
            {
                List<DBO.User> users = new List<DBO.User>();
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_User> existings = bdd.T_User.Take(max).ToList();

                    foreach (T_User user in existings)
                    {
                        DBO.User dboUser = new DBO.User();
                        dboUser.Id = user.id;
                        dboUser.Username = user.username;
                        dboUser.Email = user.email;
                        dboUser.Password = user.password;
                        dboUser.Admin = user.admin;

                        //TODO 
                        //if (!item.T_Favorite.IsLoaded)
                        //{
                        //    item.T_Favorite.Load();
                        //}
                        //STUFF LIKE THAT

                        users.Add(dboUser);
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                return new List<DBO.User>();
            }
        }
    }
}
