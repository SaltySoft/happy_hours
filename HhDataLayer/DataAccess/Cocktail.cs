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
        public static HhDBO.Cocktail GetRandomCocktail()
        {
            try
            {
                HhDBO.Cocktail dboCocktail = null;
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    int count = bdd.T_Cocktail.Count();
                    int index = new Random().Next(count);
                    T_Cocktail cocktail = bdd.T_Cocktail.OrderBy(x => x.id).Skip(index).FirstOrDefault();

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
            catch (Exception)
            {
                return null;
            }
        }

        public static List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {
            try
            {
                List<HhDBO.Cocktail> cocktails = new List<HhDBO.Cocktail>();

                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<T_Cocktail> existings;
                    if (edited)
                    {
                        existings = bdd.T_Cocktail.Where(x => x.edited == 1).ToList();
                    }
                    else
                    {
                        existings = bdd.T_Cocktail.Take(max).ToList();
                    }
                    
                    Mapper.CreateMap<T_Ingredient, HhDBO.Ingredient>();
                    foreach (T_Cocktail cocktail in existings)
                    {
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();

                        HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);

                        dboCocktail.Ingredients = new List<HhDBO.Ingredient>();

                        foreach (T_CocktailsIngredients link in cocktail.T_CocktailsIngredients)
                        {
                            T_Ingredient ingredient = link.T_Ingredient;
                            HhDBO.Ingredient dboIngredient = Mapper.Map<T_Ingredient, HhDBO.Ingredient>(ingredient);
                            dboCocktail.Ingredients.Add(dboIngredient);
                        }


                        cocktails.Add(dboCocktail);
                    }
                }
                Debug.WriteLine("Got list of cocktails");
                return cocktails;
            }
            catch (Exception)
            {
                Debug.WriteLine("Problem while getting list of cocktails");
                return new List<HhDBO.Cocktail>();
            }
        }

        public static List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            return GetListCocktailEdited(max, true);
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
                        Mapper.CreateMap<T_Ingredient, HhDBO.Ingredient>();
                        dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);

                        dboCocktail.Ingredients = new List<HhDBO.Ingredient>();

                        foreach (T_CocktailsIngredients link in cocktail.T_CocktailsIngredients)
                        {
                            T_Ingredient ingredient = link.T_Ingredient;
                            HhDBO.Ingredient dboIngredient = Mapper.Map<T_Ingredient, HhDBO.Ingredient>(ingredient);
                            dboCocktail.Ingredients.Add(dboIngredient);
                        }

                    }
                    else
                    {
                        return null;
                    }
                }

                return dboCocktail;
            }
            catch (Exception)
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
                    return cocktail;
                }
            }
            catch (Exception)
            {
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
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateCocktail(HhDBO.Cocktail cocktail)
        {
            try
            {
                //Mapper.CreateMap<T_Ingredient, HhDBO.Ingredient>();
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
                        if (cocktail.Picture_Url != null)
                            tCocktail.picture_url = cocktail.Picture_Url;
                        tCocktail.recipe = cocktail.Recipe;
                        tCocktail.T_User = creator;

                        if (cocktail.Ingredients != null)
                        {
                            foreach (HhDBO.Ingredient ingredient in cocktail.Ingredients)
                            {
                                T_CocktailsIngredients link = new T_CocktailsIngredients();
                                T_Ingredient tIngredient = bdd.T_Ingredient.Where(x => x.id == ingredient.Id).FirstOrDefault();
                                
                                if (tIngredient != null)
                                {
                                    
                                    bool create = true;
                                    foreach (T_CocktailsIngredients ex_link in tCocktail.T_CocktailsIngredients)
                                    {
                                        if (ex_link.T_Ingredient.id == tIngredient.id)
                                        {
                                            create = false;
                                        }   
                                    }

                                    if (create)
                                    {
                                        link.T_Ingredient = tIngredient;
                                        link.T_Cocktail = tCocktail;
                                        bdd.T_CocktailsIngredients.Add(link);
                                    }
                                }
                            }
                        }

                        for (int i = tCocktail.T_CocktailsIngredients.Count - 1; i >= 0; i--)
                        {
                            bool remove = true;
                            foreach (HhDBO.Ingredient c in cocktail.Ingredients)
                            {
                                if (c.Id == tCocktail.T_CocktailsIngredients.ElementAt(i).T_Ingredient.id)
                                    remove = false;
                            }
                            if (remove)
                                bdd.T_CocktailsIngredients.Remove(tCocktail.T_CocktailsIngredients.ElementAt(i));
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
