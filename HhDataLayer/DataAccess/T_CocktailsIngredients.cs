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
    
    public partial class T_CocktailsIngredients
    {
        public int id { get; set; }
        public int cocktail_id { get; set; }
        public int ingredient_id { get; set; }
    
        public virtual T_Cocktail T_Cocktail { get; set; }
        public virtual T_Ingredient T_Ingredient { get; set; }
    }
}
