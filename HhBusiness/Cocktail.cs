using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhBusiness
{
    public class Cocktail
    {
        /// <summary>
        /// retourne un cocktail au hasard
        /// </summary>
        /// <returns>un cocktail au hasard</returns>
        public static HhDBO.Cocktail GetRandomCocktail()
        {
            return HhDataLayer.DataAccess.Cocktail.GetRandomCocktail();
        }

        /// <summary>
        /// retourne la liste complete de tous les cocktails.
        /// </summary>
        /// <returns>la liste des cocktails sinon une liste vide</returns>
        public static List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            return HhDataLayer.DataAccess.Cocktail.GetListCocktail(max);
        }

        public static List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {
            return HhDataLayer.DataAccess.Cocktail.GetListCocktailEdited(max, edited);
        }

        /// <summary>
        /// retourne un cocktail
        /// </summary>
        /// <returns> le cocktail correspondant à l'id</returns>
        public static HhDBO.Cocktail GetCocktail(int id)
        {
            return HhDataLayer.DataAccess.Cocktail.GetCocktail(id);
        }

        /// <summary>
        /// permet la création d'un cocktail
        /// </summary>
        /// <param name="user">l'objet cocktail à créer</param>
        /// <returns>true si tout se passe bien sinon false</returns>
        public static HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {
            return HhDataLayer.DataAccess.Cocktail.CreateCocktail(cocktail);
        }

        /// <summary>
        /// permet de supprimer un cocktail
        /// </summary>
        /// <param name="id">id du cocktail</param>
        /// <returns>true si bien supprimé sinon false</returns>
        public static bool DeleteCocktail(int id)
        {
            return HhDataLayer.DataAccess.Cocktail.DeleteCocktail(id);
        }

        /// <summary>
        /// permet de mettre  à jour le cocktail
        /// </summary>
        /// <param name="user">l'cocktail a mettre a jour</param>
        /// <returns>true si ca c'est bien passé sinon false</returns>
        public static bool UpdateCocktail(HhDBO.Cocktail cocktail)
        {
            return HhDataLayer.DataAccess.Cocktail.UpdateCocktail(cocktail);
        }
    }
}
