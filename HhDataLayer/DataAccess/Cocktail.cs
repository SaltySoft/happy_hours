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
                        existings = bdd.T_Cocktail.ToList();
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

        public static List<HhDBO.Cocktail> GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery)
        {
            try
            {
                List<HhDBO.Cocktail> cocktails = new List<HhDBO.Cocktail>();
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    List<string> ingredients_str = new List<string>();
                    //foreach (string str in searchQuery.Ingredients.Split(' ').ToList())
                    //{
                    List<string> tmpstrs1 = searchQuery.Ingredients.Split(',').ToList();
                    foreach (string tmpstr1 in tmpstrs1)
                    {
                        List<string> tmpstrs2 = tmpstr1.Split(';').ToList();
                        foreach (string tmpstr2 in tmpstrs2)
                        {
                            if (tmpstr2 != "")
                                ingredients_str.Add(tmpstr2.Trim());
                        }
                    }
                    //}

                    int difficulty = Int32.Parse(searchQuery.Difficulty);
                    List<T_Cocktail> existings = new List<T_Cocktail>();
                    List<T_Ingredient> ingredients = new List<T_Ingredient>();
                    if (ingredients_str.Any())
                    {
                        foreach (string ingredient_str in ingredients_str)
                        {
                            ingredients.AddRange(bdd.T_Ingredient.Where(x => (x.name.Contains(ingredient_str))).ToList());
                        }
                    }

                    if (difficulty > 0 && difficulty <= 5)
                    {
                        if (searchQuery.Quick != "no")
                        {
                            existings = bdd.T_Cocktail.Where(x =>
                           (x.name.Contains(searchQuery.Cocktail_name))
                           && (x.difficulty >= (difficulty - 1) && x.difficulty <= (difficulty + 1))
                           && (x.duration < 2)).ToList();
                        }
                        else
                        {
                            existings = bdd.T_Cocktail.Where(x =>
                            (x.name.Contains(searchQuery.Cocktail_name))
                            && (x.difficulty >= (difficulty - 1) && x.difficulty <= (difficulty + 1))).ToList();
                        }
                    }
                    else
                    {
                        if (searchQuery.Quick != "no")
                        {
                            existings = bdd.T_Cocktail.Where(x =>
                              (x.name.Contains(searchQuery.Cocktail_name))
                                && (x.duration < 2)).ToList();
                        }
                        else
                        {
                            existings = bdd.T_Cocktail.Where(x =>
                            (x.name.Contains(searchQuery.Cocktail_name))).ToList();
                        }
                    }

                    List<T_Cocktail> tCocktails = new List<T_Cocktail>();
                    if (ingredients_str.Any())
                    {
                        if (ingredients.Any())
                        {
                            foreach (T_Cocktail cocktail in existings)
                            {
                                Boolean containAllIngredients = true;
                                List<T_CocktailsIngredients> joinFromCocktails = cocktail.T_CocktailsIngredients.ToList();

                                foreach (T_Ingredient ingredient in ingredients)
                                {
                                    List<T_CocktailsIngredients> joinFromIngredients = ingredient.T_CocktailsIngredients.ToList();
                                    List<T_CocktailsIngredients> both = joinFromCocktails.Intersect(joinFromIngredients).ToList();

                                    if (!both.Any())
                                    {
                                        containAllIngredients = false;
                                    }
                                }

                                if (containAllIngredients)
                                {
                                    tCocktails.Add(cocktail);
                                }
                            }
                        }
                    }
                    else
                    {
                        tCocktails = existings;
                    }

                    List<T_Cocktail> realTCocktails = new List<T_Cocktail>();
                    if (searchQuery.Alcohol != "no")
                    {
                        foreach (T_Cocktail tc in tCocktails)
                        {
                            Boolean without_alcohol = true;
                            List<T_CocktailsIngredients> joinFromCocktails = tc.T_CocktailsIngredients.ToList();

                            List<T_Ingredient> cockIng = new List<T_Ingredient>();
                            foreach (T_CocktailsIngredients tci in joinFromCocktails)
                            {
                                cockIng.AddRange(bdd.T_Ingredient.Where(x => x.id == tci.ingredient_id).ToList());
                            }

                            foreach (T_Ingredient ingredient in cockIng)
                            {
                                if (ingredient.alcool != 0)
                                {
                                    without_alcohol = false;
                                    break;
                                }
                            }
                            if (without_alcohol)
                            {
                                realTCocktails.Add(tc);
                            }
                        }
                    }
                    else
                    {
                        realTCocktails = tCocktails;
                    }

                    foreach (T_Cocktail cocktail in realTCocktails)
                    {
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();

                        HhDBO.Cocktail dboCocktail = Mapper.Map<T_Cocktail, HhDBO.Cocktail>(cocktail);
                        cocktails.Add(dboCocktail);
                    }
                }
                Debug.WriteLine("Got GetQuickSearchCocktails cocktails list");
                return cocktails;
            }
            catch (Exception)
            {
                Debug.WriteLine("Problem while getting GetQuickSearchCocktails cocktails list");
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
                        Mapper.CreateMap<T_Cocktail, HhDBO.Cocktail>();

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
                    List<T_Cocktail> existings = bdd.T_Cocktail.Where(x => x.name == cocktail.Name).ToList();
                    if (!existings.Any())
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
                    else
                    {
                        throw new HhDBO.Exceptions.AlreadyExistingException("already_existing");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteCocktail(int id)
        {
            try
            {
                using (MyHappyHoursEntities bdd = new MyHappyHoursEntities())
                {
                    T_Cocktail tCocktail = bdd.T_Cocktail.Where(x => x.id == id).FirstOrDefault();
                    List<T_CocktailsIngredients> link_ingr_rem = new List<T_CocktailsIngredients>();
                    foreach (T_CocktailsIngredients link_ingredient in tCocktail.T_CocktailsIngredients)
                    {
                        link_ingr_rem.Add(link_ingredient);

                    }

                    for (int i = link_ingr_rem.Count - 1; i >= 0; i--)
                    {
                        bdd.T_CocktailsIngredients.Remove(link_ingr_rem.ElementAt(i));
                    }
                    List<T_Favorite> fav_rem = new List<T_Favorite>();
                    foreach (T_Favorite fav in tCocktail.T_Favorite)
                    {
                        fav_rem.Add(fav);
                    }

                    for (int i = fav_rem.Count - 1; i >= 0; i--)
                    {
                        bdd.T_Favorite.Remove(fav_rem.ElementAt(i));
                    }

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
                        //if (cocktail.Name != null)
                        //{
                        //    if (cocktail.Name == "")
                        //        throw new HhDBO.Exceptions.InvalidParameterException("name");
                        //    tCocktail.name = cocktail.Name;
                        //}
                        //else
                        //{
                        //    if (tCocktail.name == "")
                        //        throw new HhDBO.Exceptions.InvalidParameterException("name");
                        //}
                        if (cocktail.Description != null)
                            tCocktail.description = cocktail.Description;
                        else
                            tCocktail.description = "";

                        tCocktail.difficulty = cocktail.Difficulty;
                        tCocktail.duration = cocktail.Duration;
                        tCocktail.edited = 1;
                        if (cocktail.Picture_Url != null)
                            tCocktail.picture_url = cocktail.Picture_Url;
                        else
                            tCocktail.picture_url = "";
                        if (cocktail.Recipe != null)
                            tCocktail.recipe = cocktail.Recipe;
                        else
                            tCocktail.recipe = "";

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
                throw ex;
            }
        }
    }
}
