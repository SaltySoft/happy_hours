using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Diagnostics;

namespace HhDataLayer.DataAccess
{
    public class Ingredient
    {
        /// <summary>
        /// retourne la liste complete de tous les ingredients.
        /// </summary>
        /// <returns>la liste des ingredients sinon une liste vide</returns>
        public static List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            try
            {
                List<HhDBO.Ingredient> ingredients = new List<HhDBO.Ingredient>();

                using(MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_Ingredient> existings = bdd.T_Ingredient.Take(max).ToList();

                    foreach (T_Ingredient ingredient in existings)
                    {
                        Mapper.CreateMap<T_Ingredient, HhDBO.Ingredient>();

                        HhDBO.Ingredient dboIngredient = Mapper.Map<T_Ingredient, HhDBO.Ingredient>(ingredient);
                        ingredients.Add(dboIngredient);
                    }
                }
                Debug.WriteLine("Got list of ingredients");
                return ingredients;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem while getting list of ingredients");
                return new List<HhDBO.Ingredient>();
            }
        }

        public static HhDBO.Ingredient GetIngredient(int id)
        {
            try
            {
                HhDBO.Ingredient dboIngredient = null;
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Ingredient ingredient = bdd.T_Ingredient.Where(x => x.id == id).FirstOrDefault();
                    
                    if (ingredient != null)
                    {
                        Mapper.CreateMap<T_Ingredient, HhDBO.Ingredient>();
                        dboIngredient = Mapper.Map<T_Ingredient, HhDBO.Ingredient>(ingredient);
                    }
                    else
                    {
                        return null;
                    }
                }

                return dboIngredient;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    Mapper.CreateMap<HhDBO.Ingredient, T_Ingredient>();
                    T_Ingredient tIngredient = Mapper.Map<HhDBO.Ingredient, T_Ingredient>(ingredient);
                    bdd.T_Ingredient.Add(tIngredient);
                    bdd.SaveChanges();
                    ingredient.Id = tIngredient.id;
                    return ingredient;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool DeleteIngredient(int id)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Ingredient tIngredient = bdd.T_Ingredient.Where(x => x.id == id).FirstOrDefault();
                    bdd.T_Ingredient.Remove(tIngredient);
                    bdd.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateIngredient(HhDBO.Ingredient ingredient)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Ingredient tIngredient = bdd.T_Ingredient.Where(x => x.id == ingredient.Id).FirstOrDefault();
                    if (tIngredient != null)
                    {
                        tIngredient.name = ingredient.Name;

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
