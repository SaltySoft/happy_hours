using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class Cocktail
    {
        public static HhDBO.Cocktail GetRandomCocktail()
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.GetRandomCocktail();
        }

        public static List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.GetListCocktail(max);
        }
        
        public static List<HhDBO.Cocktail> GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.GetQuickSearchCocktails(searchQuery);
        }
        
        public static List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {
             DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
             return dataAccess.GetListCocktailEdited(max, edited);
        }
                
        public static HhDBO.Cocktail GetCocktail(int id)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.GetCocktail(id);
        }

        public static HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.CreateCocktail(cocktail);
        }

        public static bool UpdateCocktail(HhDBO.Cocktail cocktail)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.UpdateIngrediend(cocktail);
        }

        public static bool DeleteCocktail(int id)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.DeleteCocktail(id);
        }

        public static List<string> Validate(HhDBO.Cocktail cocktail)
        {
            List<string> errors = new List<string>();
            if (cocktail.Creator_Id == null)
            {
                errors.Add("Creator_Id");
            }
            if (cocktail.Description == null)
            {
                errors.Add("Description");
            }
            if (cocktail.Difficulty == null || cocktail.Difficulty <= 0 || cocktail.Difficulty > 5)
            {
                errors.Add("Difficulty");
            }
            if (cocktail.Duration == null | cocktail.Duration <= 0)
            {
                errors.Add("Duration");
            }
            if (cocktail.Name == null)
            {
                errors.Add("Name");
            }
            if (cocktail.Picture_Url == null)
            {
                errors.Add("Picture_Url");
            }
            if (cocktail.Recipe == null)
            {
                errors.Add("Recipe");
            }
            return errors;
        }
    }
}