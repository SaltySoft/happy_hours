//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HhDataLayer.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Ingredient
    {
        public T_Ingredient()
        {
            this.T_CocktailsIngredients = new HashSet<T_CocktailsIngredients>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<T_CocktailsIngredients> T_CocktailsIngredients { get; set; }
    }
}
