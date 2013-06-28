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
                    List<T_User> existings = bdd.T_User.ToList();

                    foreach (T_User user in existings)
                    {
                        Mapper.CreateMap<T_User, HhDBO.User>();
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();
                        HhDBO.User dboUser = Mapper.Map<T_User, HhDBO.User>(user);

                        dboUser.Favorites = new List<HhDBO.Cocktail>();
                        foreach (T_Favorite fav in user.T_Favorite)
                        {
                            T_Cocktail cocktail = fav.T_Cocktail;
                            HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                            dboUser.Favorites.Add(dboCocktail);
                        }

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
                    Mapper.CreateMap<T_User, HhDBO.User>();
                    Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();
                    foreach (T_User user in existings)
                    {
                        HhDBO.User dboUser = Mapper.Map<T_User, HhDBO.User>(user);

                        dboUser.Favorites = new List<HhDBO.Cocktail>();
                        foreach (T_Favorite fav in user.T_Favorite)
                        {
                            T_Cocktail cocktail = fav.T_Cocktail;
                            HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                            dboUser.Favorites.Add(dboCocktail);
                        }

                        users.Add(dboUser);
                    }
                }

                return users;
            }
            catch (Exception)
            {
                return new List<HhDBO.User>();
            }
        }

        public static HhDBO.User GetUserByName(string username)
        {
            try
            {
                HhDBO.User dboUser = null;
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    Mapper.CreateMap<T_User, HhDBO.User>();
                    Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();
                    T_User user = bdd.T_User.Where(x => x.username == username).FirstOrDefault();
                    dboUser = Mapper.Map<T_User, HhDBO.User>(user);

                    dboUser.Favorites = new List<HhDBO.Cocktail>();
                    foreach (T_Favorite fav in user.T_Favorite)
                    {
                        T_Cocktail cocktail = fav.T_Cocktail;
                        HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                        dboUser.Favorites.Add(dboCocktail);
                    }
                }

                return dboUser;
            }
            catch (Exception ex)
            {
                return null;
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
                    List<T_User> existings = bdd.T_User.Where(x => x.username == user.Username).ToList();
                    if (!existings.Any())
                    {
                        Mapper.CreateMap<HhDBO.User, T_User>();
                        T_User tUser = Mapper.Map<HhDBO.User, T_User>(user);
                        bdd.T_User.Add(tUser);
                        bdd.SaveChanges();
                        user.Id = tUser.id;
                        return user;
                    }
                    
                }
                return null;
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
            catch (Exception)
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
                        tUser.username = user.Username != null ? user.Username : tUser.username;
                        tUser.email = user.Email != null ? user.Email : tUser.email;
                        tUser.password = user.Password != null ? user.Password : tUser.password;
                        //tUser.T_Favorite 
                        //TODO
                        List<int> ids = new List<int>();

                        if (user.Favorites == null)
                            user.Favorites = new List<HhDBO.Cocktail>();

                        foreach (HhDBO.Cocktail cocktail in user.Favorites)
                        {
                            T_Favorite favorite = new T_Favorite();
                            T_Cocktail tcocktail = bdd.T_Cocktail.Where(x => x.id == cocktail.Id).FirstOrDefault();
                            if (tcocktail != null)
                            {
                                bool create = true;
                                foreach (T_Favorite fav in tUser.T_Favorite)
                                {
                                    if (fav.T_Cocktail.id == tcocktail.id)
                                    {
                                        create = false;
                                    }
                                }

                                if (create)
                                {
                                    favorite.T_Cocktail = tcocktail;
                                    favorite.T_User = tUser;
                                    bdd.T_Favorite.Add(favorite);
                                }
                                ids.Add(tcocktail.id);
                            }
                        }

                        List<T_Favorite> remove_list = bdd.T_Favorite.Where(x => !ids.Contains(x.id)).ToList();

                        for (int i = tUser.T_Favorite.Count - 1; i >= 0; i--)
                        {
                            bool remove = true;
                            foreach (HhDBO.Cocktail c in user.Favorites)
                            {
                                if (c.Id == tUser.T_Favorite.ElementAt(i).T_Cocktail.id)
                                    remove = false;
                            }
                            if (remove)
                                bdd.T_Favorite.Remove(tUser.T_Favorite.ElementAt(i));
                        }


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
