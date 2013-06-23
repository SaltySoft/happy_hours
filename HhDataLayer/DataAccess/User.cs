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
        public static List<HhDBO.User> GetListUser(int max)
        {
            try
            {
                List<HhDBO.User> users = new List<HhDBO.User>();
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_User> existings = bdd.T_User.Take(max).ToList();

                    foreach (T_User user in existings)
                    {
                        HhDBO.User dboUser = new HhDBO.User();
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
                return new List<HhDBO.User>();
            }
        }

        /// <summary>
        /// retourne une liste contenant un utilisateur
        /// </summary>
        /// <returns>la liste contenant l'utilisateur correspondant à l'id sinon une liste vide</returns>
        public static List<HhDBO.User> GetUser(int id)
        {
            try
            {
                List<HhDBO.User> users = new List<HhDBO.User>();
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_User> existings = bdd.T_User.Where(x => x.id == id).ToList();

                    foreach (T_User user in existings)
                    {
                        HhDBO.User dboUser = new HhDBO.User();
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
                return new List<HhDBO.User>();
            }
        }
    }
}
