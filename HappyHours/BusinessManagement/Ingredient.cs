using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyHours.BusinessManagement
{
    public class Ingredient
    {
        public static List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            DataAccess.Ingredient dataAccess = new DataAccess.Ingredient();
            return dataAccess.GetListIngredient(max);
        }

        public static HhDBO.Ingredient GetIngredient(int id)
        {
            DataAccess.Ingredient dataAccess = new DataAccess.Ingredient();
            return dataAccess.GetIngredient(id);
        }

        public static HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            DataAccess.Ingredient dataAccess = new DataAccess.Ingredient();
            return dataAccess.CreateIngredient(ingredient);
        }

        public static bool UpdateIngredient(HhDBO.Ingredient ingredient)
        {
            DataAccess.Ingredient dataAccess = new DataAccess.Ingredient();
            return dataAccess.UpdateIngrediend(ingredient);
        }

        public static bool DeleteIngredient(int id)
        {
            DataAccess.Ingredient dataAccess = new DataAccess.Ingredient();
            return dataAccess.DeleteIngredient(id);
        }
    }
}