using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class Ingredient
    {

        public List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            try
            {
                List<HhDBO.Ingredient> ingredients =  HhBusiness.Ingredient.GetListIngredient(max).ToList();
                foreach (HhDBO.Ingredient i in ingredients)
                {
                    Debug.WriteLine(i.Name);
                }
                return ingredients;
            }
            catch (Exception)
            {
                return new List<HhDBO.Ingredient>();
            }
        }

        public HhDBO.Ingredient GetIngredient(int id)
        {
            try
            {
                HhDBO.Ingredient ingredient = HhBusiness.Ingredient.GetIngredient(id);
                return ingredient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            try
            {
                return HhBusiness.Ingredient.CreateIngredient(ingredient);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateIngrediend(HhDBO.Ingredient ingredient)
        {
            try
            {
                return HhBusiness.Ingredient.UpdateIngredient(ingredient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteIngredient(int id)
        {
            try
            {
                return HhBusiness.Ingredient.DeleteIngredient(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}