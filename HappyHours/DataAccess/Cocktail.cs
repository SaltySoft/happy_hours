using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class Cocktail
    {
        public HhDBO.Cocktail GetRandomCocktail()
        {

            HhDBO.Cocktail cocktail = HhBusiness.Cocktail.GetRandomCocktail();
            return cocktail;
        }

        public List<HhDBO.Cocktail> GetListCocktail(int max)
        {

            List<HhDBO.Cocktail> cocktails = HhBusiness.Cocktail.GetListCocktail(max).ToList();
            return cocktails;
        }

        public List<HhDBO.Cocktail> GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery)
        {

            List<HhDBO.Cocktail> cocktails = HhBusiness.Cocktail.GetQuickSearchCocktails(searchQuery).ToList();
            return cocktails;
        }

        public List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {

            List<HhDBO.Cocktail> cocktails = HhBusiness.Cocktail.GetListCocktailEdited(max, edited).ToList();
            return cocktails;
        }

        public HhDBO.Cocktail GetCocktail(int id)
        {

            HhDBO.Cocktail cocktail = HhBusiness.Cocktail.GetCocktail(id);
            return cocktail;
        }

        public HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {

            return HhBusiness.Cocktail.CreateCocktail(cocktail);
        }

        public bool UpdateIngrediend(HhDBO.Cocktail cocktail)
        {

            return HhBusiness.Cocktail.UpdateCocktail(cocktail);
        }

        public bool DeleteCocktail(int id)
        {

            return HhBusiness.Cocktail.DeleteCocktail(id);
        }

        public List<string> Validate(HhDBO.Cocktail cocktail)
        {
            return HhBusiness.Cocktail.Validate(cocktail);
        }

    }
}