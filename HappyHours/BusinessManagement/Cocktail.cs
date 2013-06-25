using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class Cocktail
    {
        public static List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            DataAccess.Cocktail dataAccess = new DataAccess.Cocktail();
            return dataAccess.GetListCocktail(max);
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
    }
}