//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HhBackend.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Cocktail
    {
        public T_Cocktail()
        {
            this.T_CocktailsIngredients = new HashSet<T_CocktailsIngredients>();
            this.T_Favorite = new HashSet<T_Favorite>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int difficulty { get; set; }
        public int duration { get; set; }
        public int creator_id { get; set; }
        public string description { get; set; }
        public string recipe { get; set; }
        public string picture_url { get; set; }
        public int edited { get; set; }
    
        public virtual T_User T_User { get; set; }
        public virtual ICollection<T_CocktailsIngredients> T_CocktailsIngredients { get; set; }
        public virtual ICollection<T_Favorite> T_Favorite { get; set; }
    }
}
