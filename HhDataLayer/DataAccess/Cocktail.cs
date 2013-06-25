using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhDataLayer.DataAccess
{
    public class Cocktail
    {
        /// <summary>
        /// retourne la liste complete de tous les cocktails.
        /// </summary>
        /// <returns>la liste des cocktails sinon une liste vide</returns>
        public static List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            try
            {
                List<HhDBO.Cocktail> cocktails = new List<HhDBO.Cocktail>();

                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_Cocktail> existings = bdd.T_Cocktail.Take(max).ToList();

                    foreach (T_Cocktail cocktail in existings)
                    {
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();

                        HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                        cocktails.Add(dboCocktail);
                    }
                }
                Debug.WriteLine("Got list of cocktails");
                return cocktails;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem while getting list of cocktails");
                return new List<HhDBO.Cocktail>();
            }
        }

        public static HhDBO.Cocktail GetCocktail(int id)
        {
            try
            {
                HhDBO.Cocktail dboCocktail = null;
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Cocktail cocktail = bdd.T_Cocktail.Where(x => x.id == id).FirstOrDefault();

                    if (cocktail != null)
                    {
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();
                        dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                    }
                    else
                    {
                        return null;
                    }
                }

                return dboCocktail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {
            try
            {

                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_User creator = bdd.T_User.Where(x => x.id == cocktail.Creator_Id).FirstOrDefault();
                    Mapper.CreateMap<HhDBO.Cocktail, T_Cocktail>();
                    T_Cocktail tCocktail = Mapper.Map<HhDBO.Cocktail, T_Cocktail>(cocktail);
                    tCocktail.T_User = creator;
                    bdd.T_Cocktail.Add(tCocktail);
                    bdd.SaveChanges();
                    cocktail.Id = tCocktail.id;
                    Debug.WriteLine("Created cocktail haha");
                    return cocktail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public static bool DeleteCocktail(int id)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Cocktail tCocktail = bdd.T_Cocktail.Where(x => x.id == id).FirstOrDefault();
                    bdd.T_Cocktail.Remove(tCocktail);
                    bdd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateCocktail(HhDBO.Cocktail cocktail)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Cocktail tCocktail = bdd.T_Cocktail.Where(x => x.id == cocktail.Id).FirstOrDefault();
                    T_User creator = bdd.T_User.Where(x => x.id == cocktail.Creator_Id).FirstOrDefault();
                    if (tCocktail != null)
                    {
                        tCocktail.name = cocktail.Name;
                        tCocktail.description = cocktail.Description;
                        tCocktail.difficulty = cocktail.Difficulty;
                        tCocktail.duration = cocktail.Duration;
                        tCocktail.picture_url = cocktail.Picture_Url;
                        tCocktail.recipe = cocktail.Recipe;
                        tCocktail.T_User = creator;
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
