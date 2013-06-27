using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhBusiness
{
    public class User
    {
        /// <summary>
        /// retourne la liste complete de tous les utilisateurs.
        /// </summary>
        /// <returns>la liste des utilisateurs sinon une liste vide</returns>
        public static List<HhDBO.User> GetListUser(int max)
        {
            return HhDataLayer.DataAccess.User.GetListUser(max);
        }

        /// <summary>
        /// retourne une liste contenant un utilisateur
        /// </summary>
        /// <returns>la liste contenant l'utilisateur correspondant à l'id sinon une liste vide</returns>
        public static List<HhDBO.User> GetUser(int id)
        {
            return HhDataLayer.DataAccess.User.GetUser(id);
        }

        /// <summary>
        /// retourne l'utilisateur spécifié par le nom
        /// </summary>
        /// <returns>l'utilisateur correspondant au nom</returns>
        public static HhDBO.User GetUserByName(string name)
        {
            return HhDataLayer.DataAccess.User.GetUserByName(name);
        }

         /// <summary>
        /// permet la création d'un utilisateur
        /// </summary>
        /// <param name="user">l'objet utilisateur à créer</param>
        /// <returns>true si tout se passe bien sinon false</returns>
        public static HhDBO.User CreateUser(HhDBO.User user)
        {
            return HhDataLayer.DataAccess.User.CreateUser(user);
        }

        /// <summary>
        /// permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>true si bien supprimer sinon false</returns>
        public static bool DeleteUser(int id)
        {
            return HhDataLayer.DataAccess.User.DeleteUser(id);
        }

         /// <summary>
        /// permet de mettre  à jour l'utilisateur
        /// </summary>
        /// <param name="user">l'utilisateur a mettre a jour</param>
        /// <returns>true si ca c'est binen passé sinon false</returns>
        public static bool UpdateUser(HhDBO.User user)
        {
            return HhDataLayer.DataAccess.User.UpdateUser(user);
        }
    }
}
