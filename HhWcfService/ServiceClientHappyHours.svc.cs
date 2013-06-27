using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HhWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClientHappyHours" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClientHappyHours.svc ou ServiceClientHappyHours.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClientHappyHours : IServiceClientHappyHours
    {
        //Users
        public List<HhDBO.User> GetListUser(int max)
        {
            return HhBusiness.User.GetListUser(max);
        }

        public List<HhDBO.User> GetUser(int id)
        {
            return HhBusiness.User.GetUser(id);
        }

        public HhDBO.User GetUserByName(string name)
        {
            return HhBusiness.User.GetUserByName(name);
        }

        public HhDBO.User CreateUser(HhDBO.User user)
        {
            return HhBusiness.User.CreateUser(user);
        }

        public bool DeleteUser(int id)
        {
            return HhBusiness.User.DeleteUser(id);
        }

        public bool UpdateUser(HhDBO.User user)
        {
            return HhBusiness.User.UpdateUser(user);
        }

        //Ingredients
        public List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            return HhBusiness.Ingredient.GetListIngredient(max);
        }

        public HhDBO.Ingredient GetIngredient(int id)
        {
            return HhBusiness.Ingredient.GetIngredient(id);
        }

        public HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            return HhBusiness.Ingredient.CreateIngredient(ingredient);
        }

        public bool DeleteIngredient(int id)
        {
            return HhBusiness.Ingredient.DeleteIngredient(id);
        }

        public bool UpdateIngredient(HhDBO.Ingredient ingredient)
        {
            return HhBusiness.Ingredient.UpdateIngredient(ingredient);
        }

        //Cocktails
        public HhDBO.Cocktail GetRandomCocktail()
        {
            return HhBusiness.Cocktail.GetRandomCocktail();
        }

        public List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            return HhBusiness.Cocktail.GetListCocktail(max);
        }

        public List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {
            return HhBusiness.Cocktail.GetListCocktailEdited(max, edited);
        }

        public HhDBO.Cocktail GetCocktail(int id)
        {
            return HhBusiness.Cocktail.GetCocktail(id);
        }

        public HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {
            return HhBusiness.Cocktail.CreateCocktail(cocktail);
        }

        public bool DeleteCocktail(int id)
        {
            return HhBusiness.Cocktail.DeleteCocktail(id);
        }

        public bool UpdateCocktail(HhDBO.Cocktail cocktail)
        {
            return HhBusiness.Cocktail.UpdateCocktail(cocktail);
        }
    }
}
