using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhBusiness
{
    public class Ingredient
    {
        /// <summary>
        /// retourne la liste complete de tous les ingrédients.
        /// </summary>
        /// <returns>la liste des ingrédients sinon une liste vide</returns>
        public static List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            return HhDataLayer.DataAccess.Ingredient.GetListIngredient(max);
        }

        /// <summary>
        /// retourne une liste contenant un ingrédient
        /// </summary>
        /// <returns>la liste contenant l'ingrédient correspondant à l'id sinon une liste vide</returns>
        public static HhDBO.Ingredient GetIngredient(int id)
        {
            return HhDataLayer.DataAccess.Ingredient.GetIngredient(id);
        }

        /// <summary>
        /// permet la création d'un ingrédient
        /// </summary>
        /// <param name="user">l'objet ingrédient à créer</param>
        /// <returns>true si tout se passe bien sinon false</returns>
        public static HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            return HhDataLayer.DataAccess.Ingredient.CreateIngredient(ingredient);
        }

        /// <summary>
        /// permet de supprimer un ingrédient
        /// </summary>
        /// <param name="id">id de l'ingrédient</param>
        /// <returns>true si bien supprimé sinon false</returns>
        public static bool DeleteIngredient(int id)
        {
            return HhDataLayer.DataAccess.Ingredient.DeleteIngredient(id);
        }

        /// <summary>
        /// permet de mettre  à jour l'ingrédient
        /// </summary>
        /// <param name="user">l'ingrédient a mettre a jour</param>
        /// <returns>true si ca c'est bien passé sinon false</returns>
        public static bool UpdateIngredient(HhDBO.Ingredient ingredient)
        {
            return HhDataLayer.DataAccess.Ingredient.UpdateIngredient(ingredient);
        }
    }
}
