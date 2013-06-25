using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        Mapper.CreateMap<T_User, HhDBO.User>();
                        HhDBO.User dboUser = Mapper.Map<T_User, HhDBO.User>(user);

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
                        Mapper.CreateMap<T_User, HhDBO.User>();
                        HhDBO.User dboUser = Mapper.Map<T_User, HhDBO.User>(user);

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
        /// permet la création d'un utilisateur
        /// </summary>
        /// <param name="user">l'objet utilisateur à créer</param>
        /// <returns>le user si tout se passe bien sinon null</returns>
        public static HhDBO.User CreateUser(HhDBO.User user)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    Mapper.CreateMap<HhDBO.User, T_User>();
                    T_User tUser = Mapper.Map<HhDBO.User, T_User>(user);
                    bdd.T_User.Add(tUser);
                    bdd.SaveChanges();
                    user.Id = tUser.id;
                    return user;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>true si bien supprimer sinon false</returns>
        public static bool DeleteUser(int id)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_User tUser = bdd.T_User.Where(x => x.id == id).FirstOrDefault();
                    bdd.T_User.Remove(tUser);
                    bdd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// permet de mettre  à jour l'utilisateur
        /// </summary>
        /// <param name="user">l'utilisateur a mettre a jour</param>
        /// <returns>true si ca c'est binen passé sinon false</returns>
        public static bool UpdateUser(HhDBO.User user)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_User tUser = bdd.T_User.Where(x => x.id == user.Id).FirstOrDefault();
                    if (tUser != null)
                    {
                        tUser.username = user.Username;
                        tUser.email = user.Email;
                        tUser.admin = user.Admin;
                        tUser.password = user.Password;
                        //tUser.T_Favorite
                        //TODO

                        bdd.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
